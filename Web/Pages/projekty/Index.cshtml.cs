using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess;

namespace MojeVlastniStranka.Web.Pages.projekty
{
    public class IndexModel : PageModel
    {
		private readonly DataContext context;
		private readonly BlogService blogService;

		public List<BlogPostSummary> Posts { get; set; }
		public IndexModel(DataContext context, BlogService blogService)
		{
			this.context = context;
			this.blogService = blogService;
		}

		public async Task OnGetAsync()
		{
			Posts = await blogService.GetAllProject();
		}
	}
}
