using Microsoft.EntityFrameworkCore;
using MojeVlastniStranka.DataAccess.Entities;
using Reservanto.NPS.DataAccess;

namespace MojeVlastniStranka.DataAccess
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}

		/// <summary>
		/// Definuje mapování mezi třídami a tabulkami databáze.
		/// </summary>
		/// <param name="modelBuilder">Třída, která je zodpovědná za sestavneí modelu</param>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ContactForm>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Id).ValueGeneratedOnAdd();
			});



			Seed.Initialize(modelBuilder);

			base.OnModelCreating(modelBuilder);
		}

		#region DbSet
		// Definice DbSetů pro každou třídu, kterou chceme mapovat na databázovou tabulku.

		public DbSet<ContactForm> ContactForms { get; set; }
		public DbSet<BlogPost> BlogPosts { get; set; }
		public DbSet<BlogCategory> BlogCategories { get; set; }

		public DbSet<Image> Images { get; set; }

		#endregion

	}
}
