using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Dto.Blog;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.Common.Models;
using MojeVlastniStranka.DataAccess;

namespace MojeVlastniStranka.User.Areas.Admin.Pages.Blog
{
	[Authorize]

	public class BlogCategoryModel : PageModel
	{
		private readonly BlogService blogService;
		private readonly DataContext context;

		public List<BlogCategoryDto> BlogCategory
		{
			get;
			set;
		}

		public BlogCategoryModel(DataContext context, BlogService blogService)
		{
			this.context = context;
			this.blogService = blogService;
		}

		public ResponseViewModel responseViewModel
		{
			get;
			set;
		} = null;


		/// <summary>
		/// Získá všechny blog kategorie z databáze.
		/// </summary>
		public async Task OnGetAsync()
		{
			BlogCategory = await blogService.GetAllCategoriesTask();
		}

		/// <summary>
		/// Přidání blog kategorie do databáze.
		/// </summary>
		public async Task<ActionResult> OnPostAddCategoryAsync(string CategoryNameAdd)
		{
			// Zde přistupujte k vaší službě pro přidání kategorie
			responseViewModel = await blogService.AddBlogCategory(CategoryNameAdd);

			BlogCategory = await blogService.GetAllCategoriesTask();
			return Page();
		}

		/// <summary>
		/// Odebrání blog kategorie z databáze a přesunutí popřípadných blog příspěvku náležící k smazané blog kategorii ke kategorii neurčený.
		/// </summary>
		public async Task<ActionResult> OnPostDeleteCategoryAsync(Guid Id)
		{
			BlogCategory = await blogService.GetAllCategoriesTask();

			responseViewModel = await blogService.DeleteBlogCategory(Id);

			return Page();
		}
	}
}
