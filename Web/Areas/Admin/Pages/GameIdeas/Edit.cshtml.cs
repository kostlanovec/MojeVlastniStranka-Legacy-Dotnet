using MojeVlastniStranka.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Services;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace MojeVlastniStranka.Web.Areas.Admin.Pages.GameIdeas
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly IGameIdeaService _service;
        private readonly IImageService _imageService;

        public EditModel(IGameIdeaService service, IImageService imageService)
        {
            _service = service;
            _imageService = imageService;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        public class InputModel
        {
            public Guid Id { get; set; }

            [Required]
            public string TitleCs { get; set; }

            [Required]
            public string TitleEn { get; set; }

            [Required]
            public string DescriptionCs { get; set; }

            [Required]
            public string DescriptionEn { get; set; }

            public string? ExistingImageUrl { get; set; }
            public IFormFile? ImageUpload { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var idea = await _service.GetByIdAsync(id);
            if (idea == null)
            {
                return NotFound();
            }

            Input = new InputModel
            {
                Id = idea.Id,
                TitleCs = idea.TitleCs,
                TitleEn = idea.TitleEn,
                DescriptionCs = idea.DescriptionCs,
                DescriptionEn = idea.DescriptionEn,
                ExistingImageUrl = idea.ImageUrl
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var idea = await _service.GetByIdAsync(Input.Id);
            if (idea == null)
            {
                return NotFound();
            }

            if (Input.ImageUpload != null)
            {
                var oldImageUrl = idea.ImageUrl;
                idea.ImageUrl = await _imageService.UploadImageAsync(Input.ImageUpload, "gameideas");
                await _imageService.DeleteFileAsync(oldImageUrl);
            }
            else
            {
                idea.ImageUrl = Input.ExistingImageUrl;
            }

            idea.TitleCs = Input.TitleCs;
            idea.TitleEn = Input.TitleEn;
            idea.DescriptionCs = Input.DescriptionCs;
            idea.DescriptionEn = Input.DescriptionEn;

            await _service.UpdateAsync(idea);

            return RedirectToPage("./Index");
        }
    }
}
