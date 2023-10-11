using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using MojeVlastniStranka.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

namespace MojeVlastniStranka.ApplicationCore.Dto
{
	public class EditBlogPostDto
	{
		public EditBlogPostDto(int id, string name, string slug, string description, string content, string title, string au
		, string keywords, int blogCategoryId, string filePath)
		{
			Id = id;
			Name = name;
			Slug = slug;
			Description = description;
			Content = content;
			Title = title;
			Keywords = keywords;
			BlogCategoryId = blogCategoryId;

			// Check if the file exists at the specified filePath
			// Check if the file exists at the specified filePath
			if (File.Exists(filePath))
			{
				// Create a new IFormFile from the file at the filePath
				FileUpload = new FormFile(new FileStream(filePath, FileMode.Open), 0, new FileInfo(filePath).Length, Path.GetFileName(filePath), Path.GetFileName(filePath));
			}
		}
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
		public int BlogCategoryId
		{
			get;
			set;
		}

		/// <summary>
		/// Obrázek, z kterého pak získáme url cestu.
		/// </summary>
		public IFormFile? FileUpload
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
	}
}