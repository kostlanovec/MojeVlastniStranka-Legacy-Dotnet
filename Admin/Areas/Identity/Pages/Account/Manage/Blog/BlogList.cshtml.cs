using Microsoft.AspNetCore.Mvc;
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

        public List<BlogCategoryDto> BlogCategory
        {
	        get;
	        set;
        }

        public BlogCategoryDto NewCategory
        {
	        get;
	        set;
        }

        public List<BlogPostSummary> Posts
        {
            get;
            set;
        }

        public BlogModel(DataContext context, BlogService blogService)
        {
            this.context = context;
            this.blogService = blogService;
        }

        public async Task OnGetAsync(string searchString, string author, string keyword, int category, DateTime? fromDate, DateTime? toDate)
        {
	        BlogCategory = await blogService.GetAllCategoriesTask();
			Posts = await blogService.GetFilteredBlogPosts(searchString, author, keyword, category, fromDate, toDate);
        }

        public async Task<ActionResult> OnPostAddCategoryAsync()
        {
			// Zde přistupujte k vaší službě pro přidání kategorie
			var result = await blogService.AddBlogCategory(NewCategory);

	        BlogCategory = await blogService.GetAllCategoriesTask();
	        return Page();
        }

	}
}