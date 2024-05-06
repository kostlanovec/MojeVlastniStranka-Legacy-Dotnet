using Microsoft.AspNetCore.Mvc;
using MojeVlastniStranka.DataAccess;

namespace MojeVlastniStranka.Web.Controllers
{
    public class ProjektyController : Controller
    {
	    private readonly DataContext context;

	    public ProjektyController(DataContext context)
	    {
		    this.context = context;
	    }


		public IActionResult ShowProject(string Slug)
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
