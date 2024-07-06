using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.ApplicationCore.Requests;
using Microsoft.AspNetCore.Authorization;

namespace MojeVlastniStranka.User.Areas.Admin.Pages.Marketing
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

        public void OnPost()
        {
            mailService.SendMail(NewsLetterRequest);
		}
    }
}
