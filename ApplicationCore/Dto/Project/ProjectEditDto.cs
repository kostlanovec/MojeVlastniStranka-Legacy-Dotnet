using MojeVlastniStranka.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace MojeVlastniStranka.ApplicationCore.Dto.Project
{
	public class ProjectEditDto
	{
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
		/// Vrací nebo nastavuje jméno blogu pro url.
		/// </summary>
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje url na stránku.
		/// </summary>
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
		/// Vrací nebo nastavuje obsah v html
		/// </summary>
		public string Content
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje titulek blog příspěvku. 
		/// </summary>
		public string Title
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje klíčová slova blog příspěvku.
		/// </summary>
		public string Keywords
		{
			get;
			set;
		}

		public string? NameEn { get; set; }
		public string? DescriptionEn { get; set; }
		public string? ContentEn { get; set; }
		public string? TitleEn { get; set; }
		public string? KeywordsEn { get; set; }

		/// <summary>
		/// Obrázek, z kterého pak získáme url cestu.
		/// </summary>
		public string FileUpload
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje status projektů.
		/// </summary>
		public ProjectStatusEnum ProjectStatus
		{
			get;
			set;
		}
	}
}