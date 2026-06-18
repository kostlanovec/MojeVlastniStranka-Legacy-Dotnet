#nullable disable
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.ApplicationCore.Requests;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess;

namespace MojeVlastniStranka.Web.Areas.Admin.Pages.Blog
{
	[Authorize]
	public class AddImageModel : PageModel
	{
		//todo logování, jak se s tím pracuje
		private readonly DataContext context;
		private readonly ImageService imageService;

		[BindProperty]
		public AddImageRequest Input
		{
			get;
			set;
		}

		public List<ImageDto> Images
		{
			get;
			set;
		}

		public AddImageModel(DataContext dataContext, ImageService imageService)
		{
			context = dataContext;
			this.imageService = imageService;
		}

		public async Task OnGet()
		{
			Input = new AddImageRequest();
			Images = await imageService.GetImagesAsync();
		}

		public async Task<IActionResult> OnPost()
		{
			Images = await imageService.GetImagesAsync();
			if (Input.FileUpload == null || Input.FileUpload.Length == 0)
			{
				ModelState.AddModelError(string.Empty, "Neplatný soubor.");
				return Page();
			}

			return Page();
		}

		public async Task<IActionResult> OnPostDeleteAsync(int imageId)
		{
			Images = await imageService.GetImagesAsync();
			await imageService.DeleteImageAsync(imageId);
			return Page();
		}

		public async Task<IActionResult> OnPostUpdateDescriptionAsync(int imageId, string newDescription)
		{
			await imageService.UpdateImageDescriptionAsync(imageId, newDescription);
			Images = await imageService.GetImagesAsync();
			return Page();
		}
	}
}