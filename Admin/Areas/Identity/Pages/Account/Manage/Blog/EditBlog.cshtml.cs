using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.ApplicationCore.Requests;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess.Entities;

namespace MojeVlastniStranka.Admin.Areas.Identity.Pages.Account.Manage
{
    public class EditBlogPostModel : PageModel
    {
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

	    public async Task OnGetAsync()
	    {
			EditBlogPostDto = await blogService.GetBlogPostById(Id);
            BlogCategory = await blogService.GetAllCategoriesTask();
        }

		[HttpPost]
		public async Task<IActionResult> OnPost()
		{

			EditBlogPostRequest blogPost = new EditBlogPostRequest()
			{
				Name = Input.Name,
				Title = Input.Title,
				Author = Input.Author,
				Description = Input.Description,
				Content = Input.Content,
				Keywords = Input.Keywords,
				BlogCategoryId = Input.BlogCategoryId,
				FileUpload = Input.FileUpload
			};

			blogService.UpdateBlogPost(blogPost);

			return Page();
		}
	}
}
