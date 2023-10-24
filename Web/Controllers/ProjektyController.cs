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


		public IActionResult ShowBlog(string Name)
		{
			var blogPost = context.BlogPosts.FirstOrDefault(bp => bp.Name == Name);

			if (blogPost == null)
			{
				return NotFound();
			}

			var category = context.BlogCategories.FirstOrDefault(c => c.Id == blogPost.BlogCategoryId);

			if (category == null)
			{
				return NotFound();
			}

			return View("Projekty", blogPost);
		}



	}
}
