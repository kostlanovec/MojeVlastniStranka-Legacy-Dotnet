using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.OutputCaching;
using MojeVlastniStranka.ApplicationCore.Dto.Blog;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace MojeVlastniStranka.Web.Pages
{
	[OutputCache(Duration = 6000)]
	public class IndexModel : PageModel
	{
		private readonly DataContext context;
		private readonly BlogService blogService;
		private readonly MailService mailService;

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

		public IndexModel(DataContext context, BlogService blogService, MailService mailService)
		{
			this.context = context;
			this.blogService = blogService;
			this.mailService = mailService;
		}

		public async Task OnGetAsync()
		{
			Posts = await blogService.GetThreePost();

		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				Posts = await blogService.GetThreePost();
				ModelState.AddModelError(string.Empty, "Tohle není validní email.");
				return Page();
			}

			bool isEmailAdded = mailService.AddEmailForNewsLetter(email);

			if (!isEmailAdded)
			{
				Posts = await blogService.GetThreePost();
				// Pokud email již existuje, nastavte chybu
				ModelState.AddModelError(string.Empty, "Tento email je již zaregistrován.");
				return Page();
			}

			TempData["SuccessMessage"] = "Email byl úspěšně přidán.";

			Posts = await blogService.GetThreePost();


			return Page();
		}
	}
}
