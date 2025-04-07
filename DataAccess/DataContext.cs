using Microsoft.EntityFrameworkCore;
using MojeVlastniStranka.DataAccess.Entities;
using Reservanto.NPS.DataAccess;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MojeVlastniStranka.DataAccess
{
	public class DataContext : IdentityDbContext<User>
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

			Seed.InitializeAdmin(modelBuilder);

			base.OnModelCreating(modelBuilder);
		}

		/// <summary>
		/// Aplikuje všechny potřebné migrace, aby databáze byla aktuální.
		/// </summary>
		public void ApplyMigrations(DataContext context)
		{
			if (this.Database.GetPendingMigrations().Any())
			{
				this.Database.Migrate();
			}

#if DEBUG
			try
			{
				Seed.InitializeTestData(context);
			}

			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
#endif
		}

		// Definice DbSetů pro každou třídu, kterou chceme mapovat na databázovou tabulku.
		#region DbSet
		public DbSet<ContactForm> ContactForms { get; set; }
		public DbSet<BlogPost> BlogPosts { get; set; }
		public DbSet<Project> Projects { get; set; }
		public DbSet<BlogCategory> BlogCategories { get; set; }
		public DbSet<Image> Images { get; set; }
		public DbSet<IdeaToRelease> IdeaToReleases { get; set; }
		public DbSet<ReportedBug> ReportedBugs { get; set; }
		public DbSet<Notification> Notifications { get; set; }
		public DbSet<Message> Messages { get; set; }
		public DbSet<ServiceRequest> ServiceRequests { get; set; }
		public DbSet<NewsLetter> NewsLetters { get; set; }
		public DbSet<UserSubscriptionNewsLetter> UserSubscriptionsNewsLetter { get; set; }
		#endregion
	}
}