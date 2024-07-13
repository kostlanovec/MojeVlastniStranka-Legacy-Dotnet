using Microsoft.AspNetCore.Mvc;
using MojeVlastniStranka.DataAccess;

namespace MojeVlastniStranka.Web.Controllers
{
    public class ProjektyController : BaseController
    {
	    private readonly DataContext context;

	    public ProjektyController(DataContext context)
	    {
		    this.context = context;
	    }

		public IActionResult ShowProject(string Slug)
		{
			var project = context.Projects.FirstOrDefault(bp => bp.Slug == Slug);

			if (project == null)
			{
				return NotFound();
			}

			return View("ProjectLayout", project);
		}
	}
}
