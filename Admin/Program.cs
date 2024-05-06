using Admin.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Admin.Data;
using Microsoft.AspNetCore.Identity;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess;

namespace Admin
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

#if DEBUG
            builder.Services.AddDbContext<AdminContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("AdminContextConnection")),
                ServiceLifetime.Scoped);

#else
                builder.Services.AddDbContext<AdminContext>(options =>
                    options.UseMySql(builder.Configuration.GetConnectionString("AdminContextConnection"), new MariaDbServerVersion(new Version(11, 4, 0))),
                ServiceLifetime.Scoped);
#endif
            var adminContext = builder.Services.BuildServiceProvider().GetService<AdminContext>();
            adminContext.Database.Migrate();

			builder.Services.AddDefaultIdentity<AdminUser>(options => options.SignIn.RequireConfirmedAccount = true)
				.AddRoles<IdentityRole>()
                .AddRoleManager<RoleManager<IdentityRole>>()
				.AddEntityFrameworkStores<AdminContext>();

			builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            builder.Services.AddDbContext<DataContext>(options =>
					   options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MariaDbServerVersion(new Version(11, 4, 0))),
				ServiceLifetime.Scoped);

            var dataContext = builder.Services.BuildServiceProvider().GetService<DataContext>();
            dataContext.Database.Migrate();

            builder.Services.Configure<IdentityOptions>(options =>
            {
	            options.Password.RequireDigit = true;
	            options.Password.RequireLowercase = true;
	            options.Password.RequireNonAlphanumeric = true;
	            options.Password.RequireUppercase = true;
	            options.Password.RequiredLength = 6;
	            options.Password.RequiredUniqueChars = 1;

	            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(90);
	            options.Lockout.MaxFailedAccessAttempts = 5;
	            options.Lockout.AllowedForNewUsers = true;

	            options.User.AllowedUserNameCharacters =
		            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
	            options.User.RequireUniqueEmail = false;
            });

            builder.Services.ConfigureApplicationCookie(options =>
            {
	            options.Cookie.HttpOnly = true;
	            options.ExpireTimeSpan = TimeSpan.FromDays(90);

	            options.LoginPath = "/Identity/Account/Login";
	            options.AccessDeniedPath = "/Identity/Account/AccessDenied";
	            options.SlidingExpiration = true;
            });

			builder.Services.AddScoped<ContactFormService>();
            builder.Services.AddScoped<BlogService>();
            builder.Services.AddScoped<ImageService>();
            builder.Services.AddScoped<DevelopmentService>();
			builder.Services.AddScoped<NotificationService>();
            builder.Services.AddScoped<DashboardService>();
			builder.Services.AddScoped<MailService>();
			builder.Services.AddScoped<NotificationService>();
			builder.Services.AddScoped<NotificationService>();


			builder.Services.AddRazorPages();
            builder.Services.AddControllersWithViews();
			builder.Services.AddControllers();
			var app = builder.Build();

			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
				app.UseHsts();
			}

			app.UseStatusCodePagesWithReExecute("/404/{0}");
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapRazorPages();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");
			app.Run();
		}
	}
}
