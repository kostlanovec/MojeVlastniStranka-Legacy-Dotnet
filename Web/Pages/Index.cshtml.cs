using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess;
using System.Dynamic;

namespace MojeVlastniStranka.Web.Pages
{
    public class IndexModel : PageModel
    {
		private readonly DataContext context;
		private readonly BlogService blogService;
		private readonly MailService mailService;

		public List<BlogPostSummary> Posts { get; set; }

        public string JsonLD { get; set; }

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
            JsonLD = @"
				{
					""@context"": ""http://schema.org"",
					""@type"": ""Person"",
					""name"": ""Jan Sebastián Kostlán"",
					""url"": ""https://www.kostlanovec.cz"",
					""sameAs"": [
						""https://www.linkedin.com/in/jan-kostlan-7a9bb4215"",
						""https://www.instagram.com/kostlan1/"",
						""https://github.com/kostlanovec"",
						""https://www.facebook.com/jan.sebastiankostlan.1""
					],
					""email"": ""kostlan@kostlanovec.cz"",
					""description"": ""Osobní stránka Jana Sebastiána Kostlána. Tv?rce, programátor web? a desktopových aplikací."",
					""image"": ""https://kostlanovec.cz/images/profil-photo.jpg"",
					""jobTitle"": ""Programátor""
				}";
        }

		public async Task OnPostAsync()
		{
			Posts = await blogService.GetThreePost();
			mailService.AddEmailForNewsLetter(email);
		}
	}
}
