using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.ApplicationCore.Requests;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess;
namespace MojeVlastniStranka.Admin.Areas.Identity.Pages.Account.Manage
{
	public class WriteBlogModel : PageModel
	{
		private readonly DataContext context;
		private readonly BlogService blogService;

		[BindProperty]
		public BlogPostRequest Input
		{
			get;
			set;
		}

		public List<BlogCategoryDto> BlogCategory
		{
			get;
			set;
		}

		public string SuccessMessage { get; set; } // Přidejte tuto vlastnost pro zprávu o úspěchu

		public WriteBlogModel(DataContext context, BlogService blogService)
		{
			this.context = context;
			this.blogService = blogService;
		}

		public async Task OnGetAsync()
		{
			Input = new BlogPostRequest();
			BlogCategory = await blogService.GetAllCategoriesTask();
		}

		[HttpPost]
		public async Task<IActionResult> OnPost()
		{
			BlogCategory = await blogService.GetAllCategoriesTask();
			var processingResult = await blogService.AddBlogPost(Input);

			if (processingResult.IsSuccess)
			{
				// Nastavte SuccessMessage, pokud je operace úspěšná
				SuccessMessage = "Operace byla úspěšná.";

				// Můžete provést další akci, například přesměrování na jinou stránku
				return Page();
			}
			else
			{
				foreach (var error in processingResult.Errors)
				{
					ModelState.AddModelError(string.Empty, error.ErrorMessage);
				}
				return Page(); // Pokud došlo k chybě, zůstaňte na téže stránce a zobrazte chybové zprávy.
			}
		}
	}
}
