using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Dto.Blog;
using MojeVlastniStranka.ApplicationCore.Requests;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.Common.Models;
using MojeVlastniStranka.DataAccess;
using Newtonsoft.Json;

namespace MojeVlastniStranka.User.Areas.Admin.Pages.Blog
{
	[Authorize]
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

		public string SuccessMessage
		{
			get;
			set;
		}

		public ResponseViewModel responseViewModel
		{
			get;
			set;
		} = null;

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

		public async Task<IActionResult> OnPost()
		{
			if (!ModelState.IsValid)
			{
				responseViewModel = new ResponseViewModel
				{
					IsSuccess = false,
					Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()
				};

				CookiesPostSave();

				BlogCategory = await blogService.GetAllCategoriesTask();
				return Page();
			}

			responseViewModel = await blogService.AddBlogPost(Input);
			Response.Cookies.Delete("blogFormData");

			BlogCategory = await blogService.GetAllCategoriesTask();
			return Page();
		}

		private void CookiesPostSave()
		{
			var formDataCookie = JsonConvert.SerializeObject(Input);
			Response.Cookies.Append("blogFormData", formDataCookie, new CookieOptions
			{
				Expires = DateTimeOffset.UtcNow.AddDays(1),
				HttpOnly = true,
				Secure = true
			});
		}
	}
}
