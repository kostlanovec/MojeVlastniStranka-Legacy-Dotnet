using MojeVlastniStranka.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

namespace MojeVlastniStranka.ApplicationCore.Dto.Blog
{
	public class EditBlogPostDto
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
		public Guid? BlogCategoryId
		{
			get;
			set;
		}

		/// <summary>
		/// Obrázek, z kterého pak získáme url cestu.
		/// </summary>
		public string FileUpload
		{
			get;
			set;
		}

		/// <summary>
		/// Vrací nebo nastavuje navigační vlastnost k blog kategorii.
		/// </summary>
		public BlogCategory? blogCategory
		{
			get;
			set;
		}
	}
}