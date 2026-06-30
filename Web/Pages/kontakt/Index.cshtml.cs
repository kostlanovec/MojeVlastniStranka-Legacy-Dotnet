#nullable disable
#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.ApplicationCore.Dto;

namespace MojeVlastniStranka.Web.Pages.kontakt
{
	public class kontaktModel : PageModel
	{
		private readonly DataContext context;
		private readonly FormService formService;
		private readonly Microsoft.Extensions.Localization.IStringLocalizer<SharedResource> localizer;

		[BindProperty]
		public string Honeypot
		{
			get;
			set;
		}

		public kontaktModel(DataContext context, FormService formService, Microsoft.Extensions.Localization.IStringLocalizer<SharedResource> localizer)
		{
			this.context = context;
			this.formService = formService;
			this.localizer = localizer;
		}

		[BindProperty]
		public ContactFormularDto Form
		{
			get;
			set;
		}

		/// <summary>
		/// Odeslání formuláøe.
		/// </summary>
		public IActionResult OnPost()
		{
			Form.SendTime = DateTime.Now;

			if (!string.IsNullOrWhiteSpace(Honeypot))
			{
				ModelState.AddModelError("Form", localizer["Contact_Error_Honeypot"]);
				return Page();
			}

			if (ModelState.IsValid)
			{
				formService.AddForm(Form);
				TempData["SuccessMessage"] = localizer["Contact_Success"].Value;
				return RedirectToPage();
			}
			else
			{
				ModelState.AddModelError("Form", localizer["Contact_Error_Invalid"]);
				return Page();
			}
		}
	}
}
