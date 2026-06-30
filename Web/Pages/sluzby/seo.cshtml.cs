#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.ApplicationCore.Services;

namespace MojeVlastniStranka.Web.Pages.sluzby
{
	public class seoModel : PageModel
	{
		private readonly ServicesOfferedService servicesOfferedService;
		private readonly Microsoft.Extensions.Localization.IStringLocalizer<SharedResource> localizer;

		[BindProperty]
		public ServiceRequestDto ServiceRequestDto { get; set; }

		public seoModel(ServicesOfferedService servicesOfferedService, Microsoft.Extensions.Localization.IStringLocalizer<SharedResource> localizer)
		{
			this.servicesOfferedService = servicesOfferedService;
			this.localizer = localizer;
		}

		public async Task<IActionResult> OnPostAsync()
		{
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
