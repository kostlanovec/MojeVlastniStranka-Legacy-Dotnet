using System;
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

		[Column(TypeName = "nvarchar(200)")]
		public string Name
		{
			get;
			set;
		}

		[Column(TypeName = "nvarchar(200)")]
		public string Slug
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje popisek k blog příspěvku.
		/// </summary>
		[Column(TypeName = "nvarchar(1000)")]
		public string Description
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje obsah v html.
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
		[Column(TypeName = "nvarchar(200)")]
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
		[Column(TypeName = "nvarchar(1000)")]
		public string Keywords
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje Id kategorie.
		/// </summary>
		public Guid? BlogCategoryId
		{
			get;
			set;
		}

		[Column(TypeName = "nvarchar(1000)")]
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
		public DateTime Date
		{
			get;
			set;
		}

		public static BlogPost Create(string description, string content, string title, string author, string keywords, Guid? blogCategoryId, string name, string imagePath, string slug, DateTime date)
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
				Date = date
			};

			return blogPost;
		}
	}
}
