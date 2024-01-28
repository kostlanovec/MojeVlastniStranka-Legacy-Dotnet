using System.Runtime.InteropServices.JavaScript;
using Microsoft.EntityFrameworkCore;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess;


namespace MojeVlastniStrankaFinanali
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

			builder.Services.AddDbContext<DataContext>(options =>
					options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MariaDbServerVersion(new Version(11, 4, 0))),
				ServiceLifetime.Scoped);

			// migrate
            var dataContext = builder.Services.BuildServiceProvider().GetService<DataContext>();
            dataContext.Database.Migrate();

			builder.Services.AddControllers();
			builder.Services.AddScoped<BlogService>();

			builder.Services.AddRazorPages();

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


			app.Run();
		}
	}
}
