using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Dto.Blog;
using MojeVlastniStranka.ApplicationCore.Requests;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.Common.Models;
using MojeVlastniStranka.DataAccess;

namespace MojeVlastniStranka.User.Areas.Admin.Pages.Blog
{
	[Authorize]
	public class EditBlogPostModel : PageModel
	{
		private readonly DataContext context;
		private readonly BlogService blogService;

		public EditBlogPostDto EditBlogPostDto
		{
			get;
			set;
		}

		public List<BlogCategoryDto> BlogCategory
		{
			get;
			set;

		}

		[BindProperty]
		public EditBlogPostRequest Input
		{
			get;
			set;
		}

		public EditBlogPostModel(BlogService blogService)
		{
			this.blogService = blogService;
		}

		[BindProperty(SupportsGet = true)]
		public Guid Id
		{
			get;
			set;
		}

		public string SuccessMessage
		{
			get;
			set;
		}

		public ResponseViewModel responseViewModel
		{
			get;
			set;
		} = null;
		public async Task<IActionResult> OnGetAsync()
		{
			EditBlogPostDto = await blogService.GetBlogPostById(Id);

			if (EditBlogPostDto == null)
			{
				return NotFound();
			}

			BlogCategory = await blogService.GetAllCategoriesTask();
			return Page();
		}


		public async Task<IActionResult> OnPostUpdateBlogPostAsync()
		{
			if (!ModelState.IsValid)
			{
				responseViewModel = new ResponseViewModel
				{
					IsSuccess = false,
					Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()
				};

				EditBlogPostDto = await blogService.GetBlogPostById(Id);
				BlogCategory = await blogService.GetAllCategoriesTask();
				return Page();
			}

			responseViewModel = await blogService.UpdateBlogPost(Input);

			EditBlogPostDto = await blogService.GetBlogPostById(Id);
			BlogCategory = await blogService.GetAllCategoriesTask();

			return Page();
		}

		public async Task<ActionResult> OnPostDeleteBlogByIdAsync()
		{
			await blogService.DeleteBlogPost(Id);

			return RedirectToPage("/Blog/Bloglist", new { area = "Admin" });
		}
	}
}