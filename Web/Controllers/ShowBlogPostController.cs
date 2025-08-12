using Microsoft.AspNetCore.Mvc;
using MojeVlastniStranka.DataAccess;

namespace MojeVlastniStranka.Web.Controllers
{
	public class ShowBlogPostController : BaseController
	{
		private readonly DataContext context;

		public ShowBlogPostController(DataContext context)
		{
			this.context = context;
		}

		public IActionResult Blog(string Slug)
		{
			var blogPost = context.BlogPosts.FirstOrDefault(bp => bp.Slug == Slug);

			if (blogPost == null)
			{
				return NotFound();
			}

			return View("Muchomurka", blogPost);
		}
	}
}