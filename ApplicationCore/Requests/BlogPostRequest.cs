using Microsoft.AspNetCore.Http;
using MojeVlastniStranka.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

namespace MojeVlastniStranka.ApplicationCore.Requests
{
	public class BlogPostRequest
	{
		/// <summary>
		/// Vrací nebo nastavuje Id blog příspěvku.
		/// </summary>
		[Key]
		public int? Id
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
		/// Vrací nebo nastavuje jméno blogu pro url.
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
		/// Vrací nebo nastavuje autora blog příspěvku.
		/// </summary>
		public string Author
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

		/// <summary>
		/// Vrací nebo nastavuje Id kategorie.
		/// </summary>
		public int BlogCategoryId
		{
			get;
			set;
		}

		/// <summary>
		/// Url cesta k obrázku.
		/// </summary>
		public IFormFile FileUpload
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

		public DateTime date
		{
			get;
			set;
		}
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			// to-do validace, zda se jedna o html
			if (Content == null)
			{
				yield return new ValidationResult(string.Format(Localization.Resource.ContactForm_Null_FirstName), new string[] { });
			}

			if (Description == null)
			{
				yield return new ValidationResult(string.Format(Localization.Resource.ContactForm_Null_LastName), new string[] { });
			}

			if (Title == null)
			{
				yield return new ValidationResult(string.Format(Localization.Resource.ContactForm_Null_Email), new string[] { });
			}

			if (Keywords == null)
			{
				yield return new ValidationResult(string.Format(Localization.Resource.ContactForm_Null_Email), new string[] { });

			}

		}
	}
}
