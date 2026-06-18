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
					"Vyhody-modernich-technologii",
					"<main class=\"main blog--post\"><header><h1>Proč používat moderní frameworky?</h1></header><p>V dnešní době se vývoj velmi zrychlil díky novým nástrojům a umělé inteligenci.</p></main>",
					"Základy programování pro začátečníky",
					"Jan Novák",
					"technologie, vývoj",
					category.Id,
					"popis obrazku",
					"images/psychologie.jpg",
					"zaklady-programovani",
					DateTime.Now
				);

				var blogPost2 = BlogPost.Create(
					"Cisty-kod",
					"<main class=\"main blog--post\"><header><h1>Jak psát čistý kód?</h1></header><p>Udržovat čistý kód je klíčové pro dlouhodobou udržitelnost každého projektu.</p></main>",
					"Architektura webových aplikací",
					"Petr Svoboda",
					"architektura, kod",
					category.Id,
					"ukazka kodu",
					"images/psychologie.jpg",
					"architektura-webu",
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
				var contact1 = ContactForm.Create("jan.novak@example.com", "123456789", "Dobrý den, rád bych se zeptal na možnost spolupráce na novém projektu.", DateTime.Now);
				var contact2 = ContactForm.Create("info@kostlanovec.cz", "987654321", "Dobrý, mám zájem o nové stránky vámi vyrobené. Těším se, až mi ukážete, co všechno dokážete.", DateTime.Now);

				context.ContactForms.AddRange(contact1, contact2);
				context.SaveChanges();
			}

			if (!context.IdeaToReleases.Any())
			{
				var idea = IdeaToRelease.Create("Přidat podporu pro vícejazyčný systém na blogu", DateTime.Now);
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
			modelBuilder.Entity<User>().HasData(new User
			{
				Id = "00000000-0000-0000-0000-000000000001",
				UserName = "admin",
				NormalizedUserName = "ADMIN",
				Email = "info@kostlanovec.cz",
				EmailConfirmed = true,
				NormalizedEmail = "INFO@KOSTLANOVEC.CZ",
				SecurityStamp = "00000000-0000-0000-0000-000000000002",
				ConcurrencyStamp = "00000000-0000-0000-0000-000000000004",
				PasswordHash = "[REDACTED_HASH]"
			});

			modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
			{
				Id = "00000000-0000-0000-0000-000000000003",
				Name = "admin",
				NormalizedName = "ADMIN",
				ConcurrencyStamp = "00000000-0000-0000-0000-000000000005"
			});
		}	}
}
