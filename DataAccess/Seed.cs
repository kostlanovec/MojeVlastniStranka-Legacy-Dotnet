using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MojeVlastniStranka.DataAccess.Entities;
using MojeVlastniStranka.Common.Enums;
using MojeVlastniStranka.DataAccess;

namespace Reservanto.NPS.DataAccess
{
	public class Seed
	{
		public static void InitializeTestData(DataContext context)
		{
			if (!context.BlogCategories.Any())
			{
				var blogCategoryProjekty = BlogCategory.Create("projekty");
				var blogCategoryZaklad = BlogCategory.Create("základ");
				var blogCategoryBlogPripsevky = BlogCategory.Create("blogpříspěvky");

				context.BlogCategories.AddRange(blogCategoryProjekty, blogCategoryZaklad, blogCategoryBlogPripsevky);
				context.SaveChanges();
			}

			if (!context.BlogPosts.Any())
			{
				var category = context.BlogCategories.First(); // nebo vyhledat podle jména

				var blogPost1 = BlogPost.Create(
					"moje klobasa",
					"<main class=\"main blog--post\"><header><h1>Proč používat unity engine?</h1></header><p>V dnešní době unity engine se tak moc rozvinul i skrz ai, že se to dneš již vyplatí.</p></main>",
					"Deset malých švestek",
					"Pepek Námořník",
					"rohlík, klobása",
					category.Id,
					"nene",
					"images/psychologie.jpg",
					"nene",
					DateTime.Now
				);

				var blogPost2 = BlogPost.Create(
					"moje klobasa",
					"<main class=\"main blog--post\"><header><h1>Proč používat unity engine?</h1></header><p>V dnešní době unity engine se tak moc rozvinul i skrz ai, že se to dneš již vyplatí.</p></main>",
					"Pět malých kačátek",
					"Chleba s marmeládou",
					"Jsi slizký had, nemám tě rád",
					category.Id,
					"testovani",
					"images/psychologie.jpg",
					"deset-malych-cernousku",
					DateTime.Now
				);

				context.BlogPosts.AddRange(blogPost1, blogPost2);
				context.SaveChanges();
			}

			if (!context.Images.Any())
			{
				var image1 = Image.Create("konecsveta.jpg", "konec světa");
				var image2 = Image.Create("stinminulosti.jpg", "stín minulosti");

				context.Images.AddRange(image1, image2);
				context.SaveChanges();
			}

			if (!context.ContactForms.Any())
			{
				var contact1 = ContactForm.Create("jan.novak@example.com", "123456789", "Dobrý den, rád bych se zeptal na možnost spolupráce.", DateTime.Now);
				var contact2 = ContactForm.Create("info@kostlanovec.cz", "987654321", "Dobrý, mám zájem o nové stránky vámi vyrobené. Těším se, až mi ukážete, co všechno dokážete.", DateTime.Now);

				context.ContactForms.AddRange(contact1, contact2);
				context.SaveChanges();
			}

			if (!context.IdeaToReleases.Any())
			{
				var idea = IdeaToRelease.Create("Chtěl bych vytvořit nějakou animaci na vytváření koblih", DateTime.Now);
				context.IdeaToReleases.Add(idea);
				context.SaveChanges();
			}

			if (!context.Projects.Any())
			{
				var projects = new List<Project>
				{
					Project.Create("Description 1", "<main>...</main>", "Title 1", "Keywords 1", "Project 1", "/images/tvorbaher.jpg", "slug-1", DateTime.Now, ProjectStatusEnum.Planning),
					Project.Create("Description 2", "<main>...</main>", "Title 2", "Keywords 2", "Project 2", "/images/tvorbaher.jpg", "slug-2", DateTime.Now, ProjectStatusEnum.Development),
					Project.Create("Description 3", "<main>...</main>", "Title 3", "Keywords 3", "Project 3", "/images/tvorbaher.jpg", "slug-3", DateTime.Now, ProjectStatusEnum.Finalized),
					// další projekty...
				};

				context.Projects.AddRange(projects);
				context.SaveChanges();
			}
		}

		public static void InitializeAdmin(ModelBuilder modelBuilder)
		{
			// Identity Seed Users and Roles
			var hasher = new PasswordHasher<User>();

			modelBuilder.Entity<User>().HasData(new User
			{
				Id = Guid.NewGuid().ToString(),
				UserName = "admin",
				NormalizedUserName = "ADMIN",
				Email = "info@kostlanovec.cz",
				EmailConfirmed = true,
				NormalizedEmail = "INFO@KOSTLANOVEC.CZ",
				SecurityStamp = Guid.NewGuid().ToString("D"),
				PasswordHash = hasher.HashPassword(new User(), "1je2protozebagr")
			});

			modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
			{
				Id = Guid.NewGuid().ToString(),
				Name = "admin",
				NormalizedName = "ADMIN"
			});
		}
	}
}