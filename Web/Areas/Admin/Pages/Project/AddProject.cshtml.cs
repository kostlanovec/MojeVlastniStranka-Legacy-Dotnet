#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Requests;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.Common.Models;
using MojeVlastniStranka.DataAccess;

namespace MojeVlastniStranka.Web.Areas.Admin.Pages.Project
{
	public class AddProjectModel : PageModel
	{
		private readonly DataContext context;
		private readonly ProjectService projectService;

		[BindProperty]
		public AddProjectRequest Input
		{
			get;
			set;
		}

		public string SuccessMessage
		{
			get;
			set;
		}

		public ResponseViewModel responseViewModel
		{
			get;
			set;
		} = null;

		public AddProjectModel(DataContext context, ProjectService projectService)
		{
			this.context = context;
			this.projectService = projectService;
		}

		public async Task OnGetAsync()
		{
			Input = new AddProjectRequest();
		}

		public async Task<IActionResult> OnPost()
		{
			if (!ModelState.IsValid)
			{
				responseViewModel = new ResponseViewModel
				{
					IsSuccess = false,
					Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()
				};

				/*CookiesPostSave();*/

				return Page();
			}

			responseViewModel = await projectService.AddProject(Input);
			/*Response.Cookies.Delete("blogFormData");*/

			return Page();
		}
		/*
		private void CookiesPostSave()
		{
			var formDataCookie = JsonConvert.SerializeObject(Input);
			Response.Cookies.Append("blogFormData", formDataCookie, new CookieOptions
			{
				Expires = DateTimeOffset.UtcNow.AddDays(1),
				HttpOnly = true,
				Secure = true
			});
		}*/
	}
}
