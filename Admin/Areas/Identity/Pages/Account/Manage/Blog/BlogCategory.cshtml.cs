using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess;

namespace MojeVlastniStranka.Admin.Areas.Identity.Pages.Account.Manage.Blog
{
    public class BlogCategoryModel : PageModel
    {
	    private readonly BlogService blogService;
	    private readonly DataContext context;

		public List<BlogCategoryDto> BlogCategory
	    {
		    get;
		    set;
	    }

		public BlogCategoryModel(DataContext context, BlogService blogService)
		{
			this.context = context;
			this.blogService = blogService;
		}

		public async Task OnGetAsync()
        {
	        BlogCategory = await blogService.GetAllCategoriesTask();
		}


        public async Task<ActionResult> OnPostAddCategoryAsync(string CategoryNameAdd)
        {
	        // Zde přistupujte k vaší službě pro přidání kategorie
	        var result = await blogService.AddBlogCategory(CategoryNameAdd);

	        BlogCategory = await blogService.GetAllCategoriesTask();
	        return Page();
        }

        public async Task<ActionResult> OnGetDeleteCategoryAsync(int Id)
        {
			var result = await blogService.DeleteBlogCategory(Id);

			BlogCategory = await blogService.GetAllCategoriesTask();
			return Page();
        }
	}
}
