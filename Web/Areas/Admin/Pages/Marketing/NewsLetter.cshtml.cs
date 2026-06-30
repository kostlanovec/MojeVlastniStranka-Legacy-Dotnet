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
		private readonly MailService mailService;

		[BindProperty]
		public NewsLetterRequest NewsLetterRequest
		{
			get;
			set;
		}

		public NewsLetterModel(MailService mailService)
		{
			this.mailService = mailService;
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			await mailService.SendMail(NewsLetterRequest);
			TempData["SuccessMessage"] = "Newsletter byl úspěšně rozeslán všem odběratelům.";
			return RedirectToPage();
		}
	}
}
