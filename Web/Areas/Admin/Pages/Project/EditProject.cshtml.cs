using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Dto.Blog;
using MojeVlastniStranka.ApplicationCore.Dto.Project;
using MojeVlastniStranka.ApplicationCore.Requests;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess;

namespace MojeVlastniStranka.User.Areas.Admin.Pages.Project
{
    [Authorize]
	public class EditProjectModel : PageModel
	{
		private readonly DataContext context;
		private readonly ProjectService projectService;

		public ProjectEditDto ProjectEditDto
		{
			get;
			set;
		}

		[BindProperty]
		public UpdateProjectRequest Input
		{
			get;
			set;
		}

		public EditProjectModel(ProjectService projectService, DataContext dataContext)
		{
			this.projectService = projectService;
			this.context = dataContext;
		}

		[BindProperty(SupportsGet = true)]
		public Guid Id
		{
			get;
			set;
		}

		public string SuccessMessage
		{
			get;
			set;
		}

		public async Task OnGetAsync()
		{
			ProjectEditDto = projectService.GetProjectById(Id);
		}

		public async Task<IActionResult> OnPostUpdateBlogPostAsync()
		{
			ProjectEditDto = projectService.GetProjectById(Id);
			projectService.UpdateProject(Input);
			return Page();

		}

		public async Task<ActionResult> OnPostDeleteProjectByIdAsync()
		{
			ProjectEditDto = projectService.GetProjectById(Id);
			return RedirectToPage("/Account/Manage/Project/Index");
		}
	}
}
