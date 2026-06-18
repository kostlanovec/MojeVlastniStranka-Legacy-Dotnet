using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MojeVlastniStranka.DataAccess.Entities
{
	public class BlogPost : IEntities
	{
		protected BlogPost() { }

		/// <summary>
		/// Vrací nebo nastavuje Id blog příspěvku.
		/// </summary>
		[Key]
		public Guid Id
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje jméno blogu.
		/// </summary>
		[Column(TypeName = "text")]
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje jméno blogu pro url.
		/// </summary>
		[Column(TypeName = "text")]
		public string Slug
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje popisek k blog příspěvku.
		/// </summary>

		public string Description
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje obsah v html.
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
		[Column(TypeName = "text")]
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

		[Column(TypeName = "text")]
		public string? NameEn { get; set; }

		public string? DescriptionEn { get; set; }

		[Column(TypeName = "text")]
		public string? ContentEn { get; set; }

		[Column(TypeName = "text")]
		public string? TitleEn { get; set; }

		[Column(TypeName = "text")]
		public string? KeywordsEn { get; set; }


		/// <summary>
		/// Vrací nebo nastavuje Id kategorie.
		/// </summary>
		public Guid? BlogCategoryId
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
		[ForeignKey("BlogCategoryId")]
		public BlogCategory BlogCategory
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje čas blogu.
		/// </summary>
		[Column(TypeName = "timestamp")]
		public DateTime Date
		{
			get;
			set;
		}

		public static BlogPost Create(string description, string content, string title, string author, string keywords, Guid? blogCategoryId, string name, string imagePath, string slug, DateTime date, string? nameEn = null, string? descriptionEn = null, string? contentEn = null, string? titleEn = null, string? keywordsEn = null)
		{
			var blogPost = new BlogPost()
			{
				Id = Guid.NewGuid(),
				Description = description,
				Content = content,
				Title = title,
				Author = author,
				Keywords = keywords,
				BlogCategoryId = blogCategoryId,
				Name = name,
				ImagePath = imagePath,
				Slug = slug,
				Date = date,
				NameEn = nameEn,
				DescriptionEn = descriptionEn,
				ContentEn = contentEn,
				TitleEn = titleEn,
				KeywordsEn = keywordsEn
			};

			return blogPost;
		}
	}
}
