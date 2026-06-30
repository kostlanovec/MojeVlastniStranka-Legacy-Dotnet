#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.ApplicationCore.Services;

namespace MojeVlastniStranka.Web.Pages.sluzby
{
	public class socialnisiteModel : PageModel
	{
		private readonly ServicesOfferedService servicesOfferedService;
		private readonly Microsoft.Extensions.Localization.IStringLocalizer<SharedResource> localizer;
		private readonly RecaptchaService recaptchaService;

		[BindProperty]
		public ServiceRequestDto ServiceRequestDto 
		{
			get;
			set;
		}

		public socialnisiteModel(ServicesOfferedService servicesOfferedService, Microsoft.Extensions.Localization.IStringLocalizer<SharedResource> localizer, RecaptchaService recaptchaService)
		{
			this.servicesOfferedService = servicesOfferedService;
			this.localizer = localizer;
			this.recaptchaService = recaptchaService;
		}

		public async Task<IActionResult> OnPostAsync()
		{
			var recaptchaToken = Request.Form["RecaptchaToken"];
			if (!await recaptchaService.VerifyAsync(recaptchaToken))
			{
				ModelState.AddModelError(string.Empty, localizer["Recaptcha_Error"]);
				return Page();
			}

			if (!ModelState.IsValid)
			{
				return Page();
			}

			await servicesOfferedService.AddServiceRequestAsync(ServiceRequestDto);

			TempData["SuccessMessage"] = localizer["ServiceRequest_Success"].Value;
			return RedirectToPage();
		}
	}
}
