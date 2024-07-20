using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess;

namespace MojeVlastniStranka.Web.Pages
{
    public class IndexModel : PageModel
    {
		private readonly DataContext context;
		private readonly BlogService blogService;
		private readonly MailService mailService;

		public List<BlogPostSummary> Posts { get; set; }

		[BindProperty]
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

		public async Task OnPostAsync()
		{
			Posts = await blogService.GetThreePost();
			mailService.AddEmailForNewsLetter(email);
		}
	}
}
