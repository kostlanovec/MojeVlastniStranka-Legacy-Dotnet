using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Entities;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
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

			builder.Services.AddDbContext<DataContext>(options =>
				options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")),
				ServiceLifetime.Scoped);

			builder.Services.AddDefaultIdentity<User>(options =>
			{
				options.Password.RequireDigit = true;
				options.Password.RequireLowercase = true;
				options.Password.RequireNonAlphanumeric = true;
				options.Password.RequireUppercase = true;
				options.Password.RequiredLength = 6;
				options.Password.RequiredUniqueChars = 1;

				// Lockout settings.
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
				options.Lockout.MaxFailedAccessAttempts = 5;
				options.Lockout.AllowedForNewUsers = true;

				// Uživatelské nastavení.
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

			builder.Services.AddRazorPages();
			builder.Services.AddControllersWithViews();

			builder.Services.ConfigureHealthChecks(builder.Configuration);

			var app = builder.Build();

			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
				app.UseStatusCodePagesWithReExecute("/StatusCode/{0}");
				app.UseHsts();
			}

			app.UseHttpsRedirection();

			app.MapStaticAssets();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

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

			app.MapHealthChecks("/api/health", new HealthCheckOptions()
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
			using (var scope = app.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				var context = services.GetRequiredService<DataContext>();
				context.ApplyMigrations(context);
			}
		}
	}
}