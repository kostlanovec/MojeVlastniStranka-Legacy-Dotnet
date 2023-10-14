using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.ApplicationCore.Requests;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess;

namespace MojeVlastniStranka.Admin.Areas.Identity.Pages.Account.Manage.Blog
{
    public class AddImageModel : PageModel
    {
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

        [HttpPost]
        public async Task<IActionResult> OnPost()
        {
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
            await imageService.DeleteImageAsync(imageId);
            return Page();
        }

        public async Task<IActionResult> OnPostUpdateDescriptionAsync(int imageId, string newDescription)
        {
            await imageService.UpdateImageDescriptionAsync(imageId, newDescription);
            return Page();
        }
    }
}