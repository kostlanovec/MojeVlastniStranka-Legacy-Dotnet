using Microsoft.EntityFrameworkCore;
using MojeVlastniStranka.DataAccess.Entities;
using Reservanto.NPS.DataAccess;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MojeVlastniStranka.DataAccess
{
	public class DataContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
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

        // Definice DbSetů pro každou třídu, kterou chceme mapovat na databázovou tabulku.
        #region DbSet

        public DbSet<ContactForm> ContactForms { get; set; }
		public DbSet<BlogPost> BlogPosts { get; set; }
		public DbSet<BlogCategory> BlogCategories { get; set; }

		public DbSet<Image> Images { get; set; }

		public DbSet<IdeaToRelease> IdeaToReleases { get; set; }

		public DbSet<ReportedBug> ReportedBugs { get; set; }

		public DbSet<Notification> Notifications { get; set; }

		public DbSet<Message> Messages { get; set; }

		#endregion

	}
}
