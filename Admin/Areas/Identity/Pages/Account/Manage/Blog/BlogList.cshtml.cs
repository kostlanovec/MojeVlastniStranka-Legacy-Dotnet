using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess;
namespace MojeVlastniStranka.Admin.Areas.Identity.Pages.Account.Manage.Blog
{
    public class BlogModel : PageModel
    {
        private readonly DataContext context;
        private readonly BlogService blogService;

        public List<BlogPostSummary> Posts { get; set; }
        public BlogModel(DataContext context, BlogService blogService)
        {
            this.context = context;
            this.blogService = blogService;
        }

        public async Task OnGetAsync()
        {
            Posts = await blogService.GetAllBlogPost();
        }

    }
}