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

		/// <summary>
		/// Získá všechny blog kategorie z databáze.
		/// </summary>
		public async Task OnGetAsync()
        {
	        BlogCategory = await blogService.GetAllCategoriesTask();
		}

		/// <summary>
		/// Přidání blog kategorie do databáze.
		/// </summary>
        public async Task<ActionResult> OnPostAddCategoryAsync(string CategoryNameAdd)
        {
	        // Zde přistupujte k vaší službě pro přidání kategorie
	        var result = await blogService.AddBlogCategory(CategoryNameAdd);

	        BlogCategory = await blogService.GetAllCategoriesTask();
	        return Page();
        }

		/// <summary>
		/// Odebrání blog kategorie z databáze a přesunutí popřípadných blog příspěvku náležící k smazané blog kategorii ke kategorii neurčený.
		/// </summary>
        public async Task<ActionResult> OnPostDeleteCategoryAsync(int Id)
        {
	        BlogCategory = await blogService.GetAllCategoriesTask();
			// blog kategorie je 1, což znamená
			if (Id == 1 || Id == 2)
	        {
		        return Page();
	        }
			var result = await blogService.DeleteBlogCategory(Id);

			return Page();
        }
	}
}
