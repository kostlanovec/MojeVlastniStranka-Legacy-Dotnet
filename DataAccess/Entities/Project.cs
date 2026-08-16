using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MojeVlastniStranka.Common.Enums;

namespace MojeVlastniStranka.DataAccess.Entities
{
	public class Project : IEntities
	{
		protected Project() { }

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
		/// Vrací nebo nastavuje název blog příspěvku.
		/// </summary>
		[Column(TypeName = "text")]
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje slug blog příspěvku.
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

		[Column(TypeName = "text")]
		public string? DescriptionEn { get; set; }

		[Column(TypeName = "text")]
		public string? ContentEn { get; set; }

		[Column(TypeName = "text")]
		public string? TitleEn { get; set; }

		[Column(TypeName = "text")]
		public string? KeywordsEn { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje cestu k obrázku.
		/// </summary>
		[Column(TypeName = "text")]
		public string ImagePath
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

		/// <summary>
		/// Vracé nebo nastavuje status blogu.
		/// </summary>
		[EnumDataType(typeof(ProjectStatusEnum))]
		public ProjectStatusEnum projectStatus
		{
			get;
			set;
		}

		public static Project Create(string descriptions, string content, string title, string keywords, string name, string imagePath, string slug, DateTime date, ProjectStatusEnum projectStatus, string? nameEn = null, string? descriptionEn = null, string? contentEn = null, string? titleEn = null, string? keywordsEn = null)
		{
			var blogCategory = new Project()
			{
				Id = Guid.NewGuid(),
				Description = descriptions,
				Content = content,
				Title = title,
				Keywords = keywords,
				Name = name,
				ImagePath = imagePath,
				Slug = slug,
				Date = date.Date,
				projectStatus = projectStatus,
				NameEn = nameEn,
				DescriptionEn = descriptionEn,
				ContentEn = contentEn,
				TitleEn = titleEn,
				KeywordsEn = keywordsEn
			};

			return blogCategory;
		}
	}
}
