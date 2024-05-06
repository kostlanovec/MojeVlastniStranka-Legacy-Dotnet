using Microsoft.EntityFrameworkCore;
using MojeVlastniStranka.DataAccess.Entities;
using System;

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
        }
    }
}
