using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MojeVlastniStranka.DataAccess.Entities
{
    public class BlogPost
    {
        protected BlogPost(){}
        /// <summary>
        /// Vrací nebo nastavuje Id blog příspěvku.
        /// </summary>
        [Key]
        public int? Id
        {
            get;
            set;
        }

        [Column(TypeName = "nvarchar(max)")]
        public string Name
        {
	        get;
	        set;
        }

        [Column(TypeName = "nvarchar(max)")]
        public string Slug
        {
	        get;
	        set;
        }
		/// <summary>
		/// Vrací nebo nastavuje popisek k blog příspěvku.
		/// </summary>
		[Column(TypeName = "nvarchar(max)")]

        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Vrací nebo nastavuje obsah v html
        /// </summary>
        [Column(TypeName = "nvarchar(max)")]

        public string Content
        {
            get;
            set;
        }

        /// <summary>
        /// Vrací nebo nastavuje titulek blog příspěvku. 
        /// </summary>
        [Column(TypeName = "nvarchar(max)")]

        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Vrací nebo nastavuje autora blog příspěvku.
        /// </summary>
        [Column(TypeName = "nvarchar(50)")]
        public string Author
        {
            get;
            set;
        }

        /// <summary>
        /// Vrací nebo nastavuje klíčová slova blog příspěvku.
        /// </summary>
        [Column(TypeName = "nvarchar(max)")]

        public string Keywords
        {
            get;
            set;
        }

        /// <summary>
        /// Vrací nebo nastavuje Id kategorie.
        /// </summary>
        public int BlogCategoryId
        {
            get;
            set;
        }

        [Column(TypeName = "nvarchar(max)")]
        public string ImagePath
        {
	        get;
	        set;
        }

		/// <summary>
		/// Vrací nebo nastavuje navigační vlastnost k blog kategorii.
		/// </summary>
		public BlogCategory blogCategory
        {
            get;
            set;
        }
        public static BlogPost Create(string descriptions, string content, string title, string author, string keywords, int BlogCategoryId, string name, string imagePath, string slug)
        {
            var blogCategory = new BlogPost()
            {
                Description = descriptions,
                Content = content,
                Title = title,
                Author = author,
                Keywords = keywords,
                BlogCategoryId = BlogCategoryId,
                Name = name,
                ImagePath = imagePath,
                Slug = slug
            };

            return blogCategory;
        }
#if DEBUG
        public static BlogPost Create(int id, string descriptions, string content, string title, string author, string keywords, int BlogCategoryId, string name, string imagePath, string slug)
        {
            var blogCategory = new BlogPost()
            {
                Id = id,
                Description = descriptions,
                Content = content,
                Title = title,
                Author = author,
                Keywords = keywords,
                BlogCategoryId = BlogCategoryId,
                Name = name,
                ImagePath = imagePath,
                Slug = slug
            };

            return blogCategory;
        }
#endif
    }
}
