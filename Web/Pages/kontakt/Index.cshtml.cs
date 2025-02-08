using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Entities;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.ApplicationCore.Dto;

namespace MojeVlastniStranka.Web.Pages.kontakt
{
	public class kontaktModel : PageModel
	{
		private readonly DataContext context;
		private readonly FormService formService;

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
			if (ModelState.IsValid)
			{
				formService.AddForm(Form);
			}
			else
			{
				ModelState.AddModelError("Form", "Formuláø není validní.");
			}
		}
	}
}
