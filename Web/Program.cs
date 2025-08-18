using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HealthChecks.UI.Client;

using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Entities;
using MojeVlastniStranka.Web;

namespace MojeVlastniStrankaFinanali.Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

#if Debug
            builder.Configuration.AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true);
#else
			builder.Configuration.AddJsonFile("appsettings.Production.json", optional: false, reloadOnChange: true);
#endif

			// --- DB + Identity ---
			builder.Services.AddDbContext<DataContext>(options =>
				 options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")),
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

			// --- MVC / Razor / Caching / Compression ---
			builder.Services.AddRazorPages();
			builder.Services.AddControllersWithViews();
			builder.Services.AddOutputCache();

			builder.Services.AddResponseCompression(options =>
			{
				options.EnableForHttps = true; // komprimuj i přes HTTPS
														 // (výchozí poskytovatelé: Brotli + Gzip)
			});

			builder.Services.AddResponseCaching(); // cacheování odpovědí dle hlaviček

			// --- Health checks ---
			builder.Services.ConfigureHealthChecks(builder.Configuration);

			var app = builder.Build();

			// --- Error handling + HSTS v produkci ---
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
				app.UseStatusCodePagesWithReExecute("/StatusCode/{0}");
				app.UseHsts(); // přidá Strict-Transport-Security
			}

			app.UseHttpsRedirection();

			// --- Komprese musí být před middlewarem, který zapisuje odpověď (statika, MVC) ---
			app.UseResponseCompression();

			// --- Bezpečnostní hlavičky (platí pro vše, vč. statiky) ---
			app.Use(async (ctx, next) =>
			{
				var h = ctx.Response.Headers;
				h["X-Content-Type-Options"] = "nosniff";
				h["Referrer-Policy"] = "strict-origin-when-cross-origin";
				h["X-Frame-Options"] = "DENY";
				h["Permissions-Policy"] = "geolocation=(), camera=(), microphone=()";
				await next();
			});

			// --- Statická obsah + Cache-Control ---
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

			app.UseRouting();

			// ResponseCaching / OutputCache patří před endpointy
			app.UseResponseCaching();
			app.UseOutputCache();

			app.UseAuthentication();
			app.UseAuthorization();

			// --- Endpoints ---
			app.MapRazorPages();

			app.MapControllerRoute(
				 name: "default",
				 pattern: "{controller=Home}/{action=Index}/{id?}");

			app.MapControllerRoute(
				 name: "blog",
				 pattern: "blog/{Slug}",
				 defaults: new { controller = "ShowBlogPost", action = "Blog" });

			app.MapControllerRoute(
				 name: "projekty",
				 pattern: "projekty/{Slug}",
				 defaults: new { controller = "Projekty", action = "ShowProject" });

			app.MapControllerRoute(
				 name: "api",
				 pattern: "api/{controller}/{action}/{id?}");

			app.MapHealthChecks("/api/health", new HealthCheckOptions
			{
				Predicate = _ => true,
				ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
			});

			app.MapHealthChecksUI(options =>
			{
				options.UIPath = "/healthcheck-ui";
			});

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
