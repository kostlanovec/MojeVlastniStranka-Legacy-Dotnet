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
            // Definování ukázkových blgo příspěvku.
            var blogPost1 = BlogPost.Create(1, "moje klbasa", "<h1>Ahoj</h1>", "Deset malých švestek", "Pepek Námořník", "rohlík, klobása", 1, "Jak mit obri pero", "blogimages/boxing.jpg", "Jak-mit-obri-pero");
            var blogPost2 = BlogPost.Create(2, "moje klbasa", "<h1>Projekt</h1>", "Pět malých kačátek", "Chleba s marmeládou", "Jsi slizký had, nemám tě rád", 2, "deset malych cernousku", "blogimages/boxing.jpg", "deset-malych-cernousku");

            modelBuilder.Entity<BlogPost>().HasData(blogPost1, blogPost2);

            // Definování ukázkových obchodníků.
            var merchant1 = BlogCategory.Create(1, "základ");
            var merchant2 = BlogCategory.Create(2, "blogpříspěvky");

            modelBuilder.Entity<BlogCategory>().HasData(merchant1, merchant2);

            var image1 = Image.Create(1, "konecsveta.jpg", "konec světa");
            var image2 = Image.Create(2, "stinminulosti.jpg", "stín minulosti");

            modelBuilder.Entity<Image>().HasData(image1, image2);
#endif
        }
	}
}