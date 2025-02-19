using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess.Entities;

namespace MojeVlastniStranka.Admin.Areas.Identity.Pages.Account.Manage.Marketing
{
	public class TableContentFormModelPage : PageModel
	{
		private readonly FormService formService;

		public List<ContactForm> ViewModel
		{
			get;
			set;
		}

		public TableContentFormModelPage(FormService formService)
		{
			this.formService = formService;
		}

		public async Task OnGetAsync()
		{
			ViewModel = formService.GetAllForms();
		}

		// todo přidej tam odstranění data z tabulky.
		public async Task OnPostAsync()
		{

		}
	}
}