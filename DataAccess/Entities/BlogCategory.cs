using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MojeVlastniStranka.DataAccess.Entities
{
    public class BlogCategory
    {
        protected BlogCategory() { }

        /// <summary>
        /// Vrací nebo nastavuje Id kategorie blogu.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Vrací nebo nastavuje jméno kategorie blogu.
        /// </summary>
        [Column(TypeName = "nvarchar(max)")]
        public string Name { get; set; }

        /// <summary>
        /// Vrací nebo nastavuje kolekci blog příspěvku.
        /// </summary>
        public ICollection<BlogPost> BlogPosts { get; set; }

#if DEBUG
        public static BlogCategory Create(int id, string name)
        {
            var blogCategory = new BlogCategory()
            {
                Id = id,
                Name = name
            };

            return blogCategory;
        }
        }
#else
        public static BlogCategory Create(string name)
        {
            var blogCategory = new BlogCategory()
            {
                Name = name
            };

            return blogCategory;
        }
    }
#endif

    
}
