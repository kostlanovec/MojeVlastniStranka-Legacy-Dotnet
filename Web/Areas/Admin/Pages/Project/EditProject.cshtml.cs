using MojeVlastniStranka.ApplicationCore.Interfaces;
#nullable disable
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Dto.Project;
using MojeVlastniStranka.ApplicationCore.Requests;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.Common.Models;
using MojeVlastniStranka.DataAccess;

namespace MojeVlastniStranka.Web.Areas.Admin.Pages.Project
{
	[Authorize]
	public class EditProjectModel : PageModel
	{
		private readonly DataContext context;
		private readonly IProjectService projectService;

		public ProjectEditDto ProjectEditDto
		{
			get;
			set;
		} = new ProjectEditDto();

		[BindProperty]
		public UpdateProjectRequest Input
		{
			get;
			set;
		}

		public EditProjectModel(IProjectService projectService, DataContext dataContext)
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

		public ResponseViewModel responseViewModel
		{
			get;
			set;
		} = null;

		public async Task<IActionResult> OnGetAsync()
		{
			ProjectEditDto = projectService.GetProjectById(Id);

			if (ProjectEditDto == null)
			{
				return NotFound();
			}
			return Page();
		}

		public async Task<IActionResult> OnPostUpdateProjectAsync()
		{
			if (!ModelState.IsValid)
			{
				responseViewModel = new ResponseViewModel
				{
					IsSuccess = false,
					Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()
				};

				ProjectEditDto = projectService.GetProjectById(Id);
				return Page();
			}

			responseViewModel = await projectService.UpdateProject(Input);
			ProjectEditDto = projectService.GetProjectById(Id);

			return Page();
		}

		public async Task<ActionResult> OnPostDeleteProjectByIdAsync()
		{
			projectService.GetProjectById(Id);
			return RedirectToPage("/Project/Index", new { area = "Admin" });
		}
	}
}