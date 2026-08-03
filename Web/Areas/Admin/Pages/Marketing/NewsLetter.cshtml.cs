using MojeVlastniStranka.ApplicationCore.Interfaces;
#nullable disable
#nullable disable
#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.ApplicationCore.Requests;
using Microsoft.AspNetCore.Authorization;

namespace MojeVlastniStranka.Web.Areas.Admin.Pages.Marketing
{
	[Authorize]
	public class NewsLetterModel : PageModel
	{
		private readonly IMailService mailService;

		[BindProperty]
		public NewsLetterRequest NewsLetterRequest
		{
			get;
			set;
		}

		public NewsLetterModel(IMailService mailService)
		{
			this.mailService = mailService;
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			Hangfire.BackgroundJob.Enqueue<IMailService>(m => m.SendMail(NewsLetterRequest));
			TempData["SuccessMessage"] = "Newsletter byl úspěšně přidán do fronty k rozeslání všem odběratelům.";
			return RedirectToPage();
		}
	}
}
