#nullable disable
using Microsoft.AspNetCore.Mvc;
using MojeVlastniStranka.ApplicationCore.Dto.Blog;
using MojeVlastniStranka.ApplicationCore.Services;

namespace MojeVlastniStranka.Web.Controllers
{
	[ApiController]
	[Route("[controller][action]")]
	public class BlogController : BaseController
	{
		private readonly BlogService blogService;

		public BlogController(BlogService blogService)
		{
			this.blogService = blogService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<BlogPostSummary>>> GetAllBlogPosts()
		{
			var posts = await this.blogService.GetAllBlogPost();

			if (posts.Count == 0)
			{
				return NotFound();
			}

			return Ok(posts);
		}
		public async Task<ActionResult<IEnumerable<BlogPostSummary>>> GetThreeBlogPosts()
		{
			var posts = await this.blogService.GetThreePost();

			if (posts.Count == 0)
			{
				return NotFound();
			}

			return Ok(posts);
		}
	}
}
