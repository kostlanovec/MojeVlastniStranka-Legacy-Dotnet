#nullable disable
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.ApplicationCore.Interfaces;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Entities;
using MojeVlastniStranka.Web;
using Prometheus;
using Hangfire;
using Hangfire.PostgreSql;

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

			builder.Services.AddHangfire(configuration => configuration
				.SetDataCompatibilityLevel(Hangfire.CompatibilityLevel.Version_180)
				.UseSimpleAssemblyNameTypeSerializer()
				.UseRecommendedSerializerSettings()
				.UsePostgreSqlStorage(options => options.UseNpgsqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"))));

			builder.Services.AddHangfireServer();

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
				options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
			});

			// --- App services ---
			builder.Services.AddScoped<ILoggerService, LoggerService>();
			builder.Services.AddScoped<INotificationService, NotificationService>();
			builder.Services.AddScoped<IBlogService, BlogService>();
			builder.Services.AddScoped<IProjectService, ProjectService>();
			builder.Services.AddScoped<IImageService, ImageService>();
			builder.Services.AddScoped<IDevelopmentService, DevelopmentService>();
			builder.Services.AddScoped<IDashboardService, DashboardService>();
			builder.Services.AddScoped<IMailService, MailService>();
			builder.Services.AddScoped<IFormService, FormService>();
			builder.Services.AddScoped<IServicesOfferedService, ServicesOfferedService>();
			builder.Services.AddScoped<IGameIdeaService, GameIdeaService>();
			builder.Services.AddHttpClient<IRecaptchaService, RecaptchaService>();

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

			var supportedCultures = new[] { "cs", "en" };

			static string DetectPreferredCulture(HttpContext context, string[] supported, string defaultCulture)
			{
				var header = context.Request.Headers.AcceptLanguage.ToString();
				if (string.IsNullOrWhiteSpace(header)) return defaultCulture;

				var ranked = header.Split(',')
					.Select(part =>
					{
						var segments = part.Trim().Split(';');
						var tag = segments[0].Trim();
						var quality = 1.0;
						if (segments.Length > 1
							&& segments[1].Trim().StartsWith("q=")
							&& double.TryParse(segments[1].Trim()[2..], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var q))
						{
							quality = q;
						}
						return (tag, quality);
					})
					.OrderByDescending(x => x.quality);

				foreach (var (tag, _) in ranked)
				{
					var lang = tag.Split('-')[0].ToLowerInvariant();
					if (supported.Contains(lang)) return lang;
				}
				return defaultCulture;
			}

			app.Use(async (context, next) =>
			{
				context.Response.Headers.Append("X-Frame-Options", "DENY");
				context.Response.Headers.Append("X-Xss-Protection", "1; mode=block");
				context.Response.Headers.Append("X-Content-Type-Options", "nosniff");
				context.Response.Headers.Append("Content-Security-Policy", "default-src 'self'; script-src 'self' 'unsafe-inline' https://cdnjs.cloudflare.com https://cdn.jsdelivr.net https://code.jquery.com https://www.google.com https://www.gstatic.com; style-src 'self' 'unsafe-inline' https://cdnjs.cloudflare.com https://cdn.jsdelivr.net https://fonts.googleapis.com; font-src 'self' https://fonts.gstatic.com https://cdnjs.cloudflare.com; img-src 'self' data: https:; frame-src 'self' https://www.google.com;");
				context.Response.Headers.Append("Referrer-Policy", "strict-origin-when-cross-origin");

				var path = context.Request.Path.Value ?? "/";
				var skip = path.StartsWith("/cs") || path.StartsWith("/en")
					|| path.StartsWith("/api") || path.StartsWith("/metrics")
					|| path.StartsWith("/css") || path.StartsWith("/js") || path.StartsWith("/lib")
					|| path.StartsWith("/images") || path.StartsWith("/Admin")
					|| path.StartsWith("/favicon") || path.StartsWith("/site.webmanifest")
					|| path.StartsWith("/apple-touch-icon") || path.StartsWith("/safari-pinned")
					|| path.StartsWith("/healthcheck") || path.StartsWith("/_framework")
					|| path.Equals("/robots.txt", StringComparison.OrdinalIgnoreCase)
					|| path.Equals("/sitemap.xml", StringComparison.OrdinalIgnoreCase)
					|| path.Equals("/rss.xml", StringComparison.OrdinalIgnoreCase)
					|| path.Equals("/hangfire", StringComparison.OrdinalIgnoreCase) || path.StartsWith("/hangfire/");
				if (!skip)
				{
					var preferred = DetectPreferredCulture(context, supportedCultures, "cs");
					if (preferred == "en")
					{
						context.Response.Redirect("/en" + (path == "/" ? "" : path), permanent: false);
						return;
					}
					if (path != "/")
					{
						context.Response.Redirect("/cs" + path, permanent: false);
						return;
					}
				}
				await next(context);
			});

			app.UseHttpsRedirection();

			app.UseHangfireDashboard("/hangfire", new DashboardOptions
			{
				Authorization = new[] { new HangfireAuthorizationFilter() }
			});

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

			var localizationOptions = new RequestLocalizationOptions()
				.SetDefaultCulture("cs")
				.AddSupportedCultures(supportedCultures)
				.AddSupportedUICultures(supportedCultures);

			localizationOptions.RequestCultureProviders.Clear();
			localizationOptions.RequestCultureProviders.Add(new Microsoft.AspNetCore.Localization.Routing.RouteDataRequestCultureProvider() { Options = localizationOptions });

			app.UseRouting();

			app.UseRequestLocalization(localizationOptions);

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
