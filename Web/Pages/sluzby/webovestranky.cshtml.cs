using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.ApplicationCore.Services;
namespace MojeVlastniStranka.Web.Pages.sluzby
{
	public class webovestrankyModel : PageModel
	{
		private readonly ServicesOfferedService servicesOfferedService;

		[BindProperty]
		public ServiceRequestDto ServiceRequestDto { get; set; }

		public webovestrankyModel(ServicesOfferedService servicesOfferedService)
		{
			this.servicesOfferedService = servicesOfferedService;
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			await servicesOfferedService.AddServiceRequestAsync(ServiceRequestDto);

			return Page();
		}
	}
}
