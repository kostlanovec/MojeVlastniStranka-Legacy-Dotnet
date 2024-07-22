using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Dto.Blog;
using MojeVlastniStranka.ApplicationCore.Requests;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess;

namespace MojeVlastniStranka.User.Areas.Admin.Pages.Blog
{
    [Authorize]
	public class EditBlogPostModel : PageModel
    {
	    private readonly DataContext context;
		private readonly BlogService blogService;

		public EditBlogPostDto EditBlogPostDto
		{
			get;
			set;
		}

        public List<BlogCategoryDto> BlogCategory
        {
            get;
            set;

        }

        [BindProperty]
        public EditBlogPostRequest Input
        {
	        get;
	        set;
        }

        public EditBlogPostModel(BlogService blogService)
	    {
			this.blogService = blogService;
	    }

        [BindProperty(SupportsGet = true)]
        public Guid Id
        {
            get;
            set;
        }

        public string SuccessMessage
        {
	        get;
	        set;
        }

		public async Task OnGetAsync()
	    {
			EditBlogPostDto = await blogService.GetBlogPostById(Id);
            BlogCategory = await blogService.GetAllCategoriesTask();
        }

		public async Task<IActionResult> OnPostUpdateBlogPostAsync()
		{
			EditBlogPostDto = await blogService.GetBlogPostById(Id);
			BlogCategory = await blogService.GetAllCategoriesTask();
			var processingResult = await blogService.UpdateBlogPost(Input);

			/* Zpráva má jít z applicationcore*/
			if (processingResult.IsSuccess)
			{
				SuccessMessage = "Operace byla úspěšná.";
				return Page();

			}
			else
			{
				return Page();
			}

		}

		public async Task<ActionResult> OnPostDeleteBlogByIdAsync()
		{
            EditBlogPostDto = await blogService.GetBlogPostById(Id);
            BlogCategory = await blogService.GetAllCategoriesTask();
			var processingResult = await blogService.DeleteBlogPost(Id);

			if (processingResult.IsSuccess)
			{
				return RedirectToPage("/Account/Manage/Blog/BlogList");
			}

			return RedirectToPage("/Account/Manage/Blog/BlogList");
		}
	}
}
