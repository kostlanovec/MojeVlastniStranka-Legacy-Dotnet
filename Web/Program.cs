using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Entities;


namespace MojeVlastniStrankaFinanali.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            /* builder.Services.AddDbContext<DataContext>(options =>
                     options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MariaDbServerVersion(new Version(11, 4, 0))),
             ServiceLifetime.Scoped);*/

            builder.Services.AddDbContext<DataContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")),
                ServiceLifetime.Scoped);

            /*	builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);*/

            builder.Services.AddDefaultIdentity<User>(options =>
                {
                    // Heslo nastavení.
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

                    // Uživatelské nastavnení.
                    options.User.AllowedUserNameCharacters =
                        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                    options.User.RequireUniqueEmail = false;
                })
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<DataContext>();


            builder.Services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            builder.Services.AddScoped<NotificationService>();
            builder.Services.AddScoped<BlogService>();
            builder.Services.AddScoped<ProjectService>();
            builder.Services.AddScoped<ImageService>();
            builder.Services.AddScoped<DevelopmentService>();
            builder.Services.AddScoped<DashboardService>();
            builder.Services.AddScoped<MailService>();

            builder.Services.AddRazorPages();
            builder.Services.AddControllers();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");

                app.UseStatusCodePagesWithReExecute("/StatusCode/{0}");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "blog",
                    pattern: "blog/{Slug}",
                    defaults: new { controller = "ShowBlogPost", action = "Blog" });
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "projekty",
                    pattern: "projekty/{Slug}",
                    defaults: new { controller = "Projekty", action = "ShowProject" });
            });

            // api endpoints
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "api",
                pattern: "api/{controller}/{action}/{id?}");
            });


            app.Run();
        }
    }
}
