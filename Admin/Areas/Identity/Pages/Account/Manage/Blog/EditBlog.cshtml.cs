using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.ApplicationCore.Requests;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess;

namespace MojeVlastniStranka.Admin.Areas.Identity.Pages.Account.Manage
{
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
        } = new EditBlogPostRequest();

        public EditBlogPostModel(BlogService blogService)
	    {
			this.blogService = blogService;
	    }

        [BindProperty(SupportsGet = true)]
        public int Id
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

		[HttpPost]
		public async Task<IActionResult> UpdateBlogPostAsync()
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
				foreach (var error in processingResult.Errors)
				{
					ModelState.AddModelError(string.Empty, error.ErrorMessage);
				}
				return Page();
			}
		}

		[HttpPost]
		public async Task<ActionResult> DeleteBlogByIdAsync()
		{
            EditBlogPostDto = await blogService.GetBlogPostById(Id);
            BlogCategory = await blogService.GetAllCategoriesTask();
			var processingResult = await blogService.DeleteBlogPost(EditBlogPostDto.Id);

			if (processingResult.IsSuccess)
			{
				return RedirectToPage("/Account/Manage/Blog/BlogList");
			}
			else
			{
				foreach (var error in processingResult.Errors)
				{
					ModelState.AddModelError(string.Empty, error.ErrorMessage);
				}
				return Page();

			}
		}
	}
}
