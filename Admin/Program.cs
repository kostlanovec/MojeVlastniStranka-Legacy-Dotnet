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
            var connectionString = builder.Configuration.GetConnectionString("AdminContextConnection") ?? throw new InvalidOperationException("Connection string 'AdminContextConnection' not found.");


			builder.Services.AddDbContext<AdminContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddDefaultIdentity<AdminUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AdminContext>();

            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            builder.Services.AddDbContext<DataContext>(options =>
		            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")),
	            ServiceLifetime.Scoped);

            builder.Services.Configure<IdentityOptions>(options =>
            {
	            // Password settings.
	            options.Password.RequireDigit = true;
	            options.Password.RequireLowercase = true;
	            options.Password.RequireNonAlphanumeric = true;
	            options.Password.RequireUppercase = true;
	            options.Password.RequiredLength = 6;
	            options.Password.RequiredUniqueChars = 1;

	            // Lockout settings.
	            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(90);
	            options.Lockout.MaxFailedAccessAttempts = 5;
	            options.Lockout.AllowedForNewUsers = true;

	            // User settings.
	            options.User.AllowedUserNameCharacters =
		            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
	            options.User.RequireUniqueEmail = false;
            });

            builder.Services.ConfigureApplicationCookie(options =>
            {
	            // Cookie settings
	            options.Cookie.HttpOnly = true;
	            options.ExpireTimeSpan = TimeSpan.FromDays(90);

	            options.LoginPath = "/Identity/Account/Login";
	            options.AccessDeniedPath = "/Identity/Account/AccessDenied";
	            options.SlidingExpiration = true;
            });


			builder.Services.AddScoped<DataManagementService>();
			builder.Services.AddScoped<ContactFormService>();
            builder.Services.AddScoped<BlogService>();
            builder.Services.AddScoped<ImageService>();

			// Add services to the container.
			builder.Services.AddRazorPages();
            builder.Services.AddControllers();
            builder.Services.AddControllersWithViews();
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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