using Microsoft.EntityFrameworkCore;
using MojeVlastniStranka.DataAccess.Entities;
using MojeVlastniStranka.DataAccess.Enums;

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
            Guid nerceny = Guid.NewGuid();
            Guid projekty = Guid.NewGuid();

            var blogcategory = BlogCategory.Create(nerceny, "neurčený");
            var blogcategoryProjekty = BlogCategory.Create(projekty, "projekty");

            var blogPost1 = BlogPost.Create(Guid.NewGuid(), "moje klobasa", "<h1>Ahoj</h1>", "Deset malých švestek", "Pepek Námořník", "rohlík, klobása", nerceny , "Jak mit obri pero", "blogimages/boxing.jpg", "Jak-mit-obri-pero", DateTime.Now);
            var blogPost2 = BlogPost.Create(Guid.NewGuid(), "moje klobasa", "<h1>Projekt</h1>", "Pět malých kačátek", "Chleba s marmeládou", "Jsi slizký had, nemám tě rád", projekty, "deset malych cernousku", "blogimages/boxing.jpg", "deset-malych-cernousku", DateTime.Now);

            modelBuilder.Entity<BlogPost>().HasData(blogPost1, blogPost2);

            var merchant1 = BlogCategory.Create(Guid.NewGuid(), "základ");
            var merchant2 = BlogCategory.Create(Guid.NewGuid(), "blogpříspěvky");

            modelBuilder.Entity<BlogCategory>().HasData(merchant1, merchant2);

            var image1 = Image.Create(Guid.NewGuid(), "konecsveta.jpg", "konec světa");
            var image2 = Image.Create(Guid.NewGuid(), "stinminulosti.jpg", "stín minulosti");

            modelBuilder.Entity<Image>().HasData(image1, image2);

            var contactForm1 = ContactForm.Create(Guid.NewGuid(), "Jan", "Novák", "jan.novak@example.com", "123456789", "Dobrý den, rád bych se zeptal na možnost spolupráce.", DateTime.Now);
            var contactForm2 = ContactForm.Create(Guid.NewGuid(), "Jan", "Kostlán", "info@kostlanovec.cz", "987654321", "Dobrý, mám zájem o nové stránky vámi vyrobené. Těším se, až mi ukážete, co všechno dokážete.", DateTime.Now);

            modelBuilder.Entity<ContactForm>().HasData(contactForm1, contactForm2);

            var ideaToRealse1 = IdeaToRelease.Create(Guid.NewGuid(), "Chtěl bych vytvořit nějakou animaci na vytváření koblih", DateTime.Now);

            modelBuilder.Entity<IdeaToRelease>().HasData(ideaToRealse1);

            modelBuilder.Entity<BlogCategory>().HasData(blogcategory, blogcategoryProjekty);

			var project1 = Project.Create(Guid.NewGuid(), "Description 1", "obsah", "Title 1", "Keywords 1", "Project 1", "/images/tvorbaher.jpg", "slug-1", DateTime.Now, ProjectStatus.Planning);
			var project2 = Project.Create(Guid.NewGuid(), "Description 2", "obsah", "Title 2", "Keywords 2", "Project 2", "/images/tvorbaher.jpg", "slug-2", DateTime.Now, ProjectStatus.Development);
			var project3 = Project.Create(Guid.NewGuid(), "Description 3", "obsah", "Title 3", "Keywords 3", "Project 3", "/images/tvorbaher.jpg", "slug-3", DateTime.Now, ProjectStatus.Finalized);
			var project4 = Project.Create(Guid.NewGuid(), "Description 4", "obsah", "Title 4", "Keywords 4", "Project 4", "/images/tvorbaher.jpg", "slug-4", DateTime.Now, ProjectStatus.Planning);
			var project5 = Project.Create(Guid.NewGuid(), "Description 5", "obsah", "Title 5", "Keywords 5", "Project 5", "/images/tvorbaher.jpg", "slug-5", DateTime.Now, ProjectStatus.Development);
			var project6 = Project.Create(Guid.NewGuid(), "Description 6", "obsah", "Title 6", "Keywords 6", "Project 6", "/images/tvorbaher.jpg", "slug-6", DateTime.Now, ProjectStatus.Finalized);

			modelBuilder.Entity<Project>().HasData(project1, project2, project3, project4, project5, project6);


		}
    }
}
