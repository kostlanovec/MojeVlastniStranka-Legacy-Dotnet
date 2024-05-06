using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.ApplicationCore.Services;

namespace MojeVlastniStranka.User.Areas.Admin.Pages.Marketing
{
	public class TableContentFormModelPage : PageModel
	{
		private readonly ContactFormService contactFormService;

        public List<ContactFormularDto> ViewModel
        {
            get;
            set;
        }

		public TableContentFormModelPage(ContactFormService contactFormService)
		{
			this.contactFormService = contactFormService;
		}

		public async Task OnGetAsync()
		{
			ViewModel = await contactFormService.GetAllForms();
		}
	}
}