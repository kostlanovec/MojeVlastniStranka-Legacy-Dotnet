using MojeVlastniStranka.Common.Enums;
using Microsoft.AspNetCore.Http;

namespace MojeVlastniStranka.ApplicationCore.Requests
{
	public class AddProjectRequest
	{
		/// <summary>
		/// Vrací nebo nastavuje název blog příspěvku.
		/// </summary>
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje slug blog příspěvku.
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
		/// Vrací nebo nastavuje cestu k obrázku.
		/// </summary>
		public IFormFile File
		{
			get;
			set;
		}

		/// <summary>
		/// Vracé nebo nastavuje status blogu.
		/// </summary>
		public ProjectStatusEnum projectStatus
		{
			get;
			set;
		}
	}
}
