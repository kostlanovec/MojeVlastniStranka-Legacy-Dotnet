using MojeVlastniStranka.ApplicationCore.Interfaces;
#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.OutputCaching;
using MojeVlastniStranka.ApplicationCore.Dto.Blog;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace MojeVlastniStranka.Web.Pages
{
	public class IndexModel : PageModel
	{
		private readonly DataContext context;
		private readonly IBlogService blogService;
		private readonly IMailService mailService;
		private readonly Microsoft.Extensions.Localization.IStringLocalizer<SharedResource> localizer;
		private readonly IRecaptchaService recaptchaService;

		public List<BlogPostSummary> Posts
		{
			get;
			set;
		}

		[BindProperty]
		[EmailAddress]
		public string email
		{
			get;
			set;
		}

		public IndexModel(DataContext context, IBlogService blogService, IMailService mailService, Microsoft.Extensions.Localization.IStringLocalizer<SharedResource> localizer, IRecaptchaService recaptchaService)
		{
			this.context = context;
			this.blogService = blogService;
			this.mailService = mailService;
			this.localizer = localizer;
			this.recaptchaService = recaptchaService;
		}

		public async Task OnGetAsync()
		{
			Posts = await blogService.GetThreePost();

		}

		public async Task<IActionResult> OnPostAsync()
		{
			Posts = await blogService.GetThreePost();

			var recaptchaToken = Request.Form["RecaptchaToken"];
			if (!await recaptchaService.VerifyAsync(recaptchaToken))
			{
				ModelState.AddModelError(string.Empty, localizer["Recaptcha_Error"]);
				return Page();
			}

			if (!ModelState.IsValid)
			{
				ModelState.AddModelError(string.Empty, localizer["Newsletter_Error_Invalid"]);
				return Page();
			}

			bool isEmailAdded = mailService.AddEmailForNewsLetter(email);

			if (!isEmailAdded)
			{
				// Pokud email již existuje, nastavte chybu
				ModelState.AddModelError(string.Empty, localizer["Newsletter_Error_Exists"]);
				return Page();
			}

			TempData["SuccessMessage"] = localizer["Newsletter_Success"].Value;

			return Page();
		}
	}
}
