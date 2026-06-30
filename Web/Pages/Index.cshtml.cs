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
		private readonly BlogService blogService;
		private readonly MailService mailService;
		private readonly Microsoft.Extensions.Localization.IStringLocalizer<SharedResource> localizer;

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

		public IndexModel(DataContext context, BlogService blogService, MailService mailService, Microsoft.Extensions.Localization.IStringLocalizer<SharedResource> localizer)
		{
			this.context = context;
			this.blogService = blogService;
			this.mailService = mailService;
			this.localizer = localizer;
		}

		public async Task OnGetAsync()
		{
			Posts = await blogService.GetThreePost();

		}

		public async Task<IActionResult> OnPostAsync()
		{
			Posts = await blogService.GetThreePost();

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
