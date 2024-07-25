using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Dto.Blog;
using MojeVlastniStranka.ApplicationCore.Services;

namespace MojeVlastniStranka.Web.Pages.blog
{
    public class IndexModel : PageModel
	{
		private readonly BlogService blogService;

		public IndexModel(BlogService blogService)
		{
			this.blogService = blogService;
		}

		public List<BlogCategoryWithPostsDto> CategoriesWithPosts { get; set; }

		public async Task OnGetAsync()
		{
			CategoriesWithPosts = await blogService.GetAllCategoriesPostsWitFourNewerPosts();
		}

		public async Task<IActionResult> OnGetSearchAsync(string query)
		{
			if (string.IsNullOrEmpty(query))
			{
				return new JsonResult(new List<BlogPostSummary>());
			}

			var results = await blogService.SearchBlogPostsAsync(query);
			return new JsonResult(results);
		}
	}
}