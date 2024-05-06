using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.ApplicationCore.Requests;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess;
using static System.Net.WebRequestMethods;

namespace MojeVlastniStranka.User.Areas.Admin.Pages.Blog
{
    public class AddImageModel : PageModel
    {
        //to-do logování, jak se s tím pracuje
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

#if DEBUG
	    public string UrlToImage = "http://localhost:5266";
#else
	    public string UrlToImage = "https://kostlanovec.cz";
#endif

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

            await imageService.UploadImageAsync(Input);
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