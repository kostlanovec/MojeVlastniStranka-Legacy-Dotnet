#nullable disable
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Entities;
using MojeVlastniStranka.Web;
using Prometheus;

namespace MojeVlastniStrankaFinanali.Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

#if DEBUG
            builder.Configuration.AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true);
#else
			builder.Configuration.AddJsonFile("appsettings.Production.json", optional: false, reloadOnChange: true);
#endif

			// --- DB + Identity ---
			builder.Services.AddDbContext<DataContext>(options =>
				 options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
						.ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning)),
				 ServiceLifetime.Scoped);

			builder.Services
				 .AddDefaultIdentity<User>(options =>
				 {
					 options.Password.RequireDigit = true;
					 options.Password.RequireLowercase = true;
					 options.Password.RequireNonAlphanumeric = true;
					 options.Password.RequireUppercase = true;
					 options.Password.RequiredLength = 6;
					 options.Password.RequiredUniqueChars = 1;

					 options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
					 options.Lockout.MaxFailedAccessAttempts = 5;
					 options.Lockout.AllowedForNewUsers = true;

					 options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
					 options.User.RequireUniqueEmail = false;
				 })
				 .AddRoles<IdentityRole>()
				 .AddEntityFrameworkStores<DataContext>();

			builder.Services.ConfigureApplicationCookie(options =>
			{
				options.Cookie.HttpOnly = true;
				options.ExpireTimeSpan = TimeSpan.FromDays(90);
				options.LoginPath = "/Admin/Account/Login";
				options.AccessDeniedPath = "/Admin/Account/AccessDenied";
				options.SlidingExpiration = true;
			});

			// --- App services ---
			builder.Services.AddScoped<LoggerService>();
			builder.Services.AddScoped<NotificationService>();
			builder.Services.AddScoped<BlogService>();
			builder.Services.AddScoped<ProjectService>();
			builder.Services.AddScoped<ImageService>();
			builder.Services.AddScoped<DevelopmentService>();
			builder.Services.AddScoped<DashboardService>();
			builder.Services.AddScoped<MailService>();
			builder.Services.AddScoped<FormService>();
			builder.Services.AddScoped<ServicesOfferedService>();

			builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

			builder.Services.AddRazorPages(options =>
			{
				options.Conventions.AddFolderRouteModelConvention("/", model =>
				{
					foreach (var selector in model.Selectors)
					{
						var template = selector.AttributeRouteModel.Template;
						selector.AttributeRouteModel.Template = Microsoft.AspNetCore.Mvc.ApplicationModels.AttributeRouteModel.CombineTemplates("{culture:regex(^(cs|en)$)?}", template);
					}
				});
			})
				.AddViewLocalization()
				.AddDataAnnotationsLocalization();
			builder.Services.AddControllersWithViews()
				.AddViewLocalization()
				.AddDataAnnotationsLocalization();
			builder.Services.AddOutputCache();

			builder.Services.AddResponseCompression(options =>
			{
				options.EnableForHttps = true;
			});

			builder.Services.AddResponseCaching();

			builder.Services.ConfigureHealthChecks(builder.Configuration);

			builder.Services.Configure<ForwardedHeadersOptions>(options =>
			{
				options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
			});

			var app = builder.Build();


			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
				app.UseStatusCodePagesWithReExecute("/StatusCode/{0}");
				app.UseHsts();
			}

			app.UseForwardedHeaders();

			app.UseHttpsRedirection();

			app.UseResponseCompression();

			app.MapStaticAssets();

			var oneYear = TimeSpan.FromDays(365);
			var oneMonth = TimeSpan.FromDays(30);

			app.UseStaticFiles(new StaticFileOptions
			{
				OnPrepareResponse = ctx =>
				{
					var path = ctx.File.PhysicalPath?.ToLowerInvariant() ?? "";

					if (path.EndsWith(".avif") || path.EndsWith(".webp") ||
						 path.EndsWith(".jpg") || path.EndsWith(".jpeg") ||
						 path.EndsWith(".png") || path.EndsWith(".svg"))
					{
						ctx.Context.Response.Headers["Cache-Control"] =
							 $"public,max-age={(int)oneYear.TotalSeconds},immutable";
					}
					else if (path.EndsWith(".css") || path.EndsWith(".js"))
					{
						ctx.Context.Response.Headers["Cache-Control"] =
							 $"public,max-age={(int)oneMonth.TotalSeconds}";
					}
				}
			});

			var supportedCultures = new[] { "cs", "en" };
			var localizationOptions = new RequestLocalizationOptions()
				.SetDefaultCulture("cs")
				.AddSupportedCultures(supportedCultures)
				.AddSupportedUICultures(supportedCultures);

			localizationOptions.RequestCultureProviders.Insert(0, new Microsoft.AspNetCore.Localization.Routing.RouteDataRequestCultureProvider() { Options = localizationOptions });

			app.UseRouting();

			app.UseRequestLocalization(localizationOptions);

			app.UseResponseCaching();
			app.UseOutputCache();

			app.UseAuthentication();
			app.UseAuthorization();

			app.MapRazorPages();

			app.MapControllerRoute(
				 name: "default",
				 pattern: "{culture:regex(^(cs|en)$)?}/{controller=Home}/{action=Index}/{id?}");

			app.MapControllerRoute(
				 name: "blog",
				 pattern: "{culture:regex(^(cs|en)$)?}/blog/{Slug}",
				 defaults: new { controller = "ShowBlogPost", action = "Blog" });

			app.MapControllerRoute(
				 name: "projekty",
				 pattern: "{culture:regex(^(cs|en)$)?}/projekty/{Slug}",
				 defaults: new { controller = "Projekty", action = "ShowProject" });

			app.MapControllerRoute(
				 name: "api",
				 pattern: "api/{controller}/{action}/{id?}");

			app.MapHealthChecks("/api/health", new HealthCheckOptions
			{
				Predicate = _ => true
			});

            app.MapMetrics("/metrics");

            EnsureLatestDatabase(app);

            app.Run();
		}

		public static void EnsureLatestDatabase(WebApplication app)
		{
			using var scope = app.Services.CreateScope();
			var services = scope.ServiceProvider;
			var context = services.GetRequiredService<DataContext>();
			context.ApplyMigrations(context);
		}
	}
}
