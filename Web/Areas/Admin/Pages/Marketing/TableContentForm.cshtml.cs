using MojeVlastniStranka.ApplicationCore.Interfaces;
#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess.Entities;

namespace MojeVlastniStranka.Admin.Areas.Identity.Pages.Account.Manage.Marketing
{
	public class TableContentFormModelPage : PageModel
	{
		private readonly IFormService formService;

		public List<ContactForm> ViewModel
		{
			get;
			set;
		}

		public TableContentFormModelPage(IFormService formService)
		{
			this.formService = formService;
		}

		public async Task OnGetAsync()
		{
			ViewModel = formService.GetAllForms();
		}

		public IActionResult OnPostDeleteAsync(Guid id)
		{
			formService.DeleteForm(id);
			return RedirectToPage();
		}
	}
}