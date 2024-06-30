using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Enums;
using MojeVlastniStranka.DataAccess.Entities;

namespace MojeVlastniStranka.Web.Pages.projekty
{
    public class IndexModel : PageModel
    {
		private readonly DataContext context;
		private readonly ProjectService blogService;

		public IndexModel(DataContext context, ProjectService blogService)
		{
			this.context = context;
			this.blogService = blogService;
		}

        [HttpGet("projekty/{status}")]
        public async Task<IActionResult> GetProjectsByStatus(string status)
        {
            IEnumerable<Project> projects;

            if (Enum.TryParse(status, out ProjectStatus projectStatus))
            {
                projects = await blogService.GetProjectsByStatus(projectStatus);
            }
            else
            {
                projects = Enumerable.Empty<Project>();
            }

            return new JsonResult(projects);
        }


    }
}