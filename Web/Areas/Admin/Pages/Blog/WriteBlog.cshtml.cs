using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Dto.Blog;
using MojeVlastniStranka.ApplicationCore.Requests;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess;

namespace MojeVlastniStranka.User.Areas.Admin.Pages.Blog
{
    [Authorize]
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
			await blogService.AddBlogPost(Input);

			return Page();
		}
	}
}
