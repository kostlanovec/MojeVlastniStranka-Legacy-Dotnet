using Microsoft.AspNetCore.Mvc;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess;

namespace MojeVlastniStranka.Web.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProjectController : BaseController
	{
		private readonly DataContext context;
		private readonly BlogService blogService;

		public List<BlogPostSummary> Posts { get; set; }
		public ProjectController(DataContext context, BlogService blogService)
		{
			this.context = context;
			this.blogService = blogService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<BlogPostSummary>>> GetAllProject()
		{
			var posts = await blogService.GetAllProject();

			if (posts.Count == 0)
			{
				return NotFound();
			}

			return Ok(posts);
		}
	}
}