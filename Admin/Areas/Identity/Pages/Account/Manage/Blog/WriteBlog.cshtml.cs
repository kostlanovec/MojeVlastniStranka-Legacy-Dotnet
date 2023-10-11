using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.ApplicationCore.Requests;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess;
namespace MojeVlastniStranka.Admin.Areas.Identity.Pages.Account.Manage
{
	/*to-do no reload page/*/
    public class WriteBlogModel : PageModel
    {
	    private readonly DataContext context;
		private readonly BlogService blogService;

		[BindProperty]
	    public BlogPostRequest Input
	    {
		    get;
		    set;
	    }

	    public List<BlogCategoryDto> BlogCategory
	    {
		    get;
		    set;

	    }

		public WriteBlogModel(DataContext context, BlogService blogService)
	    {
			this.context = context;
			this.blogService = blogService;
	    }

	    public async Task OnGetAsync()
		{
	        Input = new BlogPostRequest();
	        BlogCategory = await blogService.GetAllCategoriesTask();
		}

		[HttpPost]
        public async Task<IActionResult> OnPost()
        {
            if (Input.File == null || Input.File.Length == 0)
            {
                ModelState.AddModelError(string.Empty, "Neplatný soubor.");
                return Page();
            }

			await blogService.AddBlogPost(Input);
			
			return Page();
        }
	}
}
