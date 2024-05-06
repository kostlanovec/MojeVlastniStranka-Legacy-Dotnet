using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MojeVlastniStranka.DataAccess.Entities
{
    public class BlogCategory: IEntities
    {
        protected BlogCategory() { }

        /// <summary>
        /// Vrací nebo nastavuje Id kategorie blogu.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Vrací nebo nastavuje jméno kategorie blogu.
        /// </summary>
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        /// <summary>
        /// Vrací nebo nastavuje kolekci blog příspěvku.
        /// </summary>
        public ICollection<BlogPost> BlogPosts { get; set; }

        public static BlogCategory Create(Guid id, string name)
        {
            var blogCategory = new BlogCategory()
            {
                Id = id,
                Name = name
            };

            return blogCategory;
        }
    }

    
}
