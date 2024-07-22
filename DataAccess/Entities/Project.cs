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
        [Column(TypeName = "nvarchar(200)")]
        public string Name
		{
			get;
			set;
		}

        /// <summary>
        /// Vrací nebo nastavuje slug blog příspěvku.
        /// </summary>
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
        [Column(TypeName = "nvarchar(200)")]
        public string Title
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
        /// Vrací nebo nastavuje cestu k obrázku.
        /// </summary>
        [Column(TypeName = "nvarchar(1000)")]
        public string ImagePath
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

		/// <summary>
		/// Vracé nebo nastavuje status blogu.
		/// </summary>
		[EnumDataType(typeof(ProjectStatusEnum))]
		public ProjectStatusEnum projectStatus
		{
			get;
			set;
		}

		public static Project Create(string descriptions, string content, string title, string keywords, string name, string imagePath, string slug, DateTime date, ProjectStatusEnum projectStatus)
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
				projectStatus = projectStatus
			};

			return blogCategory;
		}
	}
}
