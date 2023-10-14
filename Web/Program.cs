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
					options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")),
				ServiceLifetime.Scoped);

			builder.Services.AddControllers();
			builder.Services.AddScoped<BlogService>();

			// Add services to the container.
			builder.Services.AddRazorPages();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");

                app.UseStatusCodePagesWithReExecute("/StatusCode/{0}");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
		            defaults: new { controller = "Projekty", action = "ShowBlog" });
            });
			app.Run();
		}
	}
}