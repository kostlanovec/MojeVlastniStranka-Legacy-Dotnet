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

		[BindProperty]
		public string Honeypot
		{
			get;
			set;
		}

		public kontaktModel(DataContext context, FormService formService)
		{
			this.context = context;
			this.formService = formService;
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
		public void OnPost()
		{
			Form.SendTime = DateTime.Now;

			// 🛡️ Kontrola honeypotu
			if (!string.IsNullOrWhiteSpace(Honeypot))
			{
				// Spam bot to vyplnil -> ignorujeme
				ModelState.AddModelError("Form", "Neplatný pokus o odeslání formuláře.");
				return;
			}

			if (ModelState.IsValid)
			{
				formService.AddForm(Form);
			}
			else
			{
				ModelState.AddModelError("Form", "Formulář není validní.");
			}
		}
	}
}
