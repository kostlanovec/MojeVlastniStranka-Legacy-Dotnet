using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

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

        [Column(TypeName = "text")]
        public string Name
        {
	        get;
	        set;
        }

        [Column(TypeName = "text")]
        public string Slug
        {
	        get;
	        set;
        }
		/// <summary>
		/// Vrací nebo nastavuje popisek k blog příspěvku.
		/// </summary>
		[Column(TypeName = "text")]

        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Vrací nebo nastavuje obsah v html
        /// </summary>
        [Column(TypeName = "text")]

        public string Content
        {
            get;
            set;
        }

        /// <summary>
        /// Vrací nebo nastavuje titulek blog příspěvku. 
        /// </summary>
        [Column(TypeName = "text")]

        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Vrací nebo nastavuje autora blog příspěvku.
        /// </summary>
        [Column(TypeName = "varchar(50)")]
        public string Author
        {
            get;
            set;
        }

        /// <summary>
        /// Vrací nebo nastavuje klíčová slova blog příspěvku.
        /// </summary>
        [Column(TypeName = "text")]

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

        [Column(TypeName = "text")]
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

        /// <summary>
        /// Vrací nebo nastavuje čas blogu.
        /// </summary>
		public DateTime Date
		{
			get;
			set;
		}

        public static BlogPost Create(string descriptions, string content, string title, string author, string keywords, int BlogCategoryId, string name, string imagePath, string slug, DateTime date)
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
                Slug = slug,
                Date = date
            };

            return blogCategory;
        }
#if DEBUG
        public static BlogPost Create(int id, string descriptions, string content, string title, string author, string keywords, int BlogCategoryId, string name, string imagePath, string slug, DateTime date)
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
                Slug = slug, 
                Date = date
            };

            return blogCategory;
        }
#endif
    }
}
