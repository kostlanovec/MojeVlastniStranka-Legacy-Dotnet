using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.Common.Enums;

namespace MojeVlastniStranka.Web.Areas.Admin.Pages.Project
{
	public class IndexModel : PageModel
	{
		private readonly DataContext context;
		private readonly ProjectService projectService;

		public IndexModel(DataContext context, ProjectService projectService)
		{
			this.context = context;
			this.projectService = projectService;
		}
		public List<DataAccess.Entities.Project> Projects { get; set; }

		public void OnGet(string searchString, string author, string keyword, Guid category, DateTime? fromDate, DateTime? toDate)
		{
			Projects = projectService.GetAllProjects(); 

		}
	}
}
