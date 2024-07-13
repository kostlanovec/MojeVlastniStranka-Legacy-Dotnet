using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MojeVlastniStranka.DataAccess.Entities;
using MojeVlastniStranka.Common.Enums;

namespace Reservanto.NPS.DataAccess
{
    public class Seed
    {
        /// <summary>
        /// Initializes the database with sample data if it has not been populated yet.
        /// </summary>
        /// <param name="modelBuilder">ModelBuilder used to configure the data model.</param>
        public static void Initialize(ModelBuilder modelBuilder)
        {
            // Create BlogCategories using the Create method
            var blogCategoryProjekty = BlogCategory.Create("projekty");
            var blogCategoryZaklad = BlogCategory.Create("základ");
            var blogCategoryBlogPripsevky = BlogCategory.Create("blogpříspěvky");

            // Seed BlogCategories
            modelBuilder.Entity<BlogCategory>().HasData(
                new { blogCategoryProjekty.Id, blogCategoryProjekty.Name },
                new { blogCategoryZaklad.Id, blogCategoryZaklad.Name },
                new { blogCategoryBlogPripsevky.Id, blogCategoryBlogPripsevky.Name }
            );

            // Create BlogPosts
            var blogPost1 = BlogPost.Create(
                "moje klobasa", "<h1>Ahoj</h1>", "Deset malých švestek", "Pepek Námořník",
                "rohlík, klobása", blogCategoryProjekty.Id, "Jak mit obri pero", "imaablogimages/boxing.jpg", "Jak-mit-obri-pero", DateTime.Now);

            var blogPost2 = BlogPost.Create(
                "moje klobasa", "<h1>Projekt</h1>", "Pět malých kačátek", "Chleba s marmeládou",
                "Jsi slizký had, nemám tě rád", blogCategoryProjekty.Id, "deset malych cernousku", "blogimages/boxing.jpg", "deset-malych-cernousku", DateTime.Now);

            // Seed BlogPosts
            modelBuilder.Entity<BlogPost>().HasData(blogPost1, blogPost2);

            // Create and Seed Images
            var image1 = Image.Create("konecsveta.jpg", "konec světa");
            var image2 = Image.Create("stinminulosti.jpg", "stín minulosti");
            modelBuilder.Entity<Image>().HasData(image1, image2);

            // Create and Seed ContactForms
            var contactForm1 = ContactForm.Create("jan.novak@example.com", "123456789", "Dobrý den, rád bych se zeptal na možnost spolupráce.", DateTime.Now);
            var contactForm2 = ContactForm.Create("info@kostlanovec.cz", "987654321", "Dobrý, mám zájem o nové stránky vámi vyrobené. Těším se, až mi ukážete, co všechno dokážete.", DateTime.Now);
            modelBuilder.Entity<ContactForm>().HasData(contactForm1, contactForm2);

            // Create and Seed IdeaToRelease
            var ideaToRealse1 = IdeaToRelease.Create("Chtěl bych vytvořit nějakou animaci na vytváření koblih", DateTime.Now);
            modelBuilder.Entity<IdeaToRelease>().HasData(ideaToRealse1);

            // Create and Seed Projects
            var projects = new List<Project>
            {
                Project.Create("Description 1", "obsah", "Title 1", "Keywords 1", "Project 1", "/images/tvorbaher.jpg", "slug-1", DateTime.Now, ProjectStatus.Planning),
                Project.Create("Description 2", "obsah", "Title 2", "Keywords 2", "Project 2", "/images/tvorbaher.jpg", "slug-2", DateTime.Now, ProjectStatus.Development),
                Project.Create("Description 3", "obsah", "Title 3", "Keywords 3", "Project 3", "/images/tvorbaher.jpg", "slug-3", DateTime.Now, ProjectStatus.Finalized),
                Project.Create("Description 4", "obsah", "Title 4", "Keywords 4", "Project 4", "/images/tvorbaher.jpg", "slug-4", DateTime.Now, ProjectStatus.Planning),
                Project.Create("Description 5", "obsah", "Title 5", "Keywords 5", "Project 5", "/images/tvorbaher.jpg", "slug-5", DateTime.Now, ProjectStatus.Development),
                Project.Create("Description 6", "obsah", "Title 6", "Keywords 6", "Project 6", "/images/tvorbaher.jpg", "slug-6", DateTime.Now, ProjectStatus.Finalized)
            };

            modelBuilder.Entity<Project>().HasData(projects);

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
                PasswordHash = hasher.HashPassword(new User(), "[REDACTED]")
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
