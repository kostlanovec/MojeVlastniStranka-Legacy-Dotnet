using Microsoft.EntityFrameworkCore;
using MojeVlastniStranka.DataAccess.Entities;

namespace Reservanto.NPS.DataAccess
{
    public class Seed
    {
        /// <summary>
        /// Inicializuje databázi se vzorovými daty, pokud nebyla již naplněna.
        /// </summary>
        /// <param name="modelBuilder">ModelBuilder používaný pro konfiguraci datového modelu.</param>
        public static void Initialize(ModelBuilder modelBuilder)
        {
#if DEBUG
            // Definování ukázkových blog příspěvku.
            var blogPost1 = BlogPost.Create(1, "moje klobasa", "<h1>Ahoj</h1>", "Deset malých švestek", "Pepek Námořník", "rohlík, klobása", 1, "Jak mit obri pero", "blogimages/boxing.jpg", "Jak-mit-obri-pero", DateTime.Now);
            var blogPost2 = BlogPost.Create(2, "moje klobasa", "<h1>Projekt</h1>", "Pět malých kačátek", "Chleba s marmeládou", "Jsi slizký had, nemám tě rád", 2, "deset malych cernousku", "blogimages/boxing.jpg", "deset-malych-cernousku", DateTime.Now);

            modelBuilder.Entity<BlogPost>().HasData(blogPost1, blogPost2);

            var merchant1 = BlogCategory.Create(4, "základ");
            var merchant2 = BlogCategory.Create(3, "blogpříspěvky");

            modelBuilder.Entity<BlogCategory>().HasData(merchant1, merchant2);

            var image1 = Image.Create(1, "konecsveta.jpg", "konec světa");
            var image2 = Image.Create(2, "stinminulosti.jpg", "stín minulosti");

            modelBuilder.Entity<Image>().HasData(image1, image2);

            var contactForm1 = ContactForm.Create(10, "Jan", "Novák", "jan.novak@example.com", "123456789", "Dobrý den, rád bych se zeptal na možnost spolupráce.", DateTime.Now);
            var contactForm2 = ContactForm.Create(20, "Jan", "Kostlán", "info@kostlanovec.cz", "987654321", "Dobrý, mám zájem o nové stránky vámi vyrobené. Těším se, až mi ukážete, co všechno dokážete.", DateTime.Now);

            modelBuilder.Entity<ContactForm>().HasData(contactForm1, contactForm2);

            var ideaToRealse1 = IdeaToRelease.Create(1, "Chtěl bych vytvořit nějakou animaci na vytváření koblih", DateTime.Now);

            modelBuilder.Entity<IdeaToRelease>().HasData(ideaToRealse1);

            var testnotification = Notification.Create(1, DateTime.Now, "Testovací notifikace");

            modelBuilder.Entity<Notification>().HasData(testnotification);
#endif
            // Podstatná část blogů, kterou potřebujeme v případě neurčení nebo smazání blog kategorie, protože se to bude seedovat.
	        var blogcategory = BlogCategory.Create(1, "neurčený");

            // Tohle je specifický pro můj blog, jelikož chci mít rozdělený projekty a blog příspěvky.
	        var blogcategoryProjekty = BlogCategory.Create(2, "projekty");

	        modelBuilder.Entity<BlogCategory>().HasData(blogcategory, blogcategoryProjekty);
        }
	}
}