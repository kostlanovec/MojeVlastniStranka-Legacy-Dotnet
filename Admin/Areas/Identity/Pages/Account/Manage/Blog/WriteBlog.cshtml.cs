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

		public string SuccessMessage
		{
			get; 
			set;
		}

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
				// to-do to by se mělo "načíst" z ApplicationCore.
				SuccessMessage = "Operace byla úspěšná.";

				return Page();
			}
			else
			{
				foreach (var error in processingResult.Errors)
				{
					ModelState.AddModelError(string.Empty, error.ErrorMessage);
				}
				return Page();
			}
		}
	}
}
