using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MojeVlastniStranka.DataAccess
{

	/// <summary>
	/// Implementuje metodu pro vytváření DbContext instance.
	/// </summary>
	public class DbContextFactory : IDesignTimeDbContextFactory<DataContext>
	{
		public DataContext CreateDbContext(string[] args)
		{
			// Vytváří konfigurační instanci pomocí ConfigurationBuilder,
			// nastavuje cestu k aktuálnímu adresáři a načítá konfigurační data z JSON souboru "appsettings.json".
			IConfiguration Configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();

			var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

			var connectionString = Configuration.GetConnectionString("DefaultConnection") ?? "Host=127.0.0.1;Port=5432;Database=postgres;User Id=postgres;Password=";
			optionsBuilder.UseNpgsql(connectionString);

			// Vytváří novou instanci DataContextu s nastavenými možnostmi.
			DataContext context = new DataContext(optionsBuilder.Options);

			return context;
		}
	}
}