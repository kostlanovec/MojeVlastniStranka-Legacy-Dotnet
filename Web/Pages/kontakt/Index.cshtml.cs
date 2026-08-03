using MojeVlastniStranka.ApplicationCore.Interfaces;
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
		private readonly IFormService formService;
		private readonly Microsoft.Extensions.Localization.IStringLocalizer<SharedResource> localizer;
		private readonly IRecaptchaService recaptchaService;

		[BindProperty]
		public string Honeypot
		{
			get;
			set;
		}

		public kontaktModel(DataContext context, IFormService formService, Microsoft.Extensions.Localization.IStringLocalizer<SharedResource> localizer, IRecaptchaService recaptchaService)
		{
			this.context = context;
			this.formService = formService;
			this.localizer = localizer;
			this.recaptchaService = recaptchaService;
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
		public async Task<IActionResult> OnPostAsync()
		{
			Form.SendTime = DateTime.Now;

			var recaptchaToken = Request.Form["RecaptchaToken"];
			if (!await recaptchaService.VerifyAsync(recaptchaToken))
			{
				ModelState.AddModelError("Form", localizer["Recaptcha_Error"]);
				return Page();
			}

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
