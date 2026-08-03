using MojeVlastniStranka.ApplicationCore.Interfaces;
#nullable disable
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Entities;

namespace MojeVlastniStranka.Web.Pages.projekty
{
	public class IndexModel : PageModel
	{
		private readonly DataContext context;
		private readonly IProjectService projectService;

		public IndexModel(DataContext context, IProjectService blogService)
		{
			this.context = context;
			this.projectService = blogService;
		}

		public List<Project> AllProjects
		{
			get;
			set;
		}

		public async Task OnGetAsync()
		{
			AllProjects = projectService.GetAllProjects();
		}

		/*
		[HttpGet("projekty/{status}")]
		public async Task<IActionResult> GetProjectsByStatus(string status)
		{
			 IEnumerable<Project> projects;

			 if (Enum.TryParse(status, out ProjectStatus projectStatus))
			 {
				  projects = await projectService.GetProjectsByStatus(projectStatus);
			 }
			 else
			 {
				  projects = Enumerable.Empty<Project>();
			 }

			 return new JsonResult(projects);
		}
		*/
	}
}