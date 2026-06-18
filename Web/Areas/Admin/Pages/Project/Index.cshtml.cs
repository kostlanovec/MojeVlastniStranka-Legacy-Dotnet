#nullable disable
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.Common.Enums;
using MojeVlastniStranka.ApplicationCore.Dto.Project;

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

		public List<ProjectSummaryDto> Projects
		{
			get;
			set;
		}

		public void OnGetAsync(string? search, ProjectStatusEnum? projectStatusEnum)
		{
			Projects = projectService.GetProjectsByStatusDateSearchString(projectStatusEnum, search);

		}
	}
}
