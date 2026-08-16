using Microsoft.AspNetCore.Http;
using MojeVlastniStranka.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace MojeVlastniStranka.ApplicationCore.Requests
{
	public class UpdateProjectRequest
	{
		/// <summary>
		/// Vrací nebo nastavuje Id projektu.
		/// </summary>
		[Key]
		public Guid Id
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje název projektu.
		/// </summary>
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje title.
		/// </summary>
		public string Title
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje popis projektu.
		/// </summary>
		public string Description
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje stav projektu.
		/// </summary>
		public ProjectStatusEnum Status
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje url projektu.
		/// </summary>
		public string Slug
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje obsah projektů.
		/// </summary>
		public string Content
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje klíčová slova.y
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
		/// Url cesta k obrázku.
		/// </summary>
		public IFormFile? FileUpload
		{
			get;
			set;
		}
	}
}
