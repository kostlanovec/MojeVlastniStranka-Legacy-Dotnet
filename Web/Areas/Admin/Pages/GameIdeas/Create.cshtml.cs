using MojeVlastniStranka.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using MojeVlastniStranka.Common.Models;

namespace MojeVlastniStranka.Web.Areas.Admin.Pages.GameIdeas
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IGameIdeaService _service;
        private readonly IImageService _imageService;

        public CreateModel(IGameIdeaService service, IImageService imageService)
        {
            _service = service;
            _imageService = imageService;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        public ResponseViewModel responseViewModel { get; set; }

        public class InputModel
        {
            [Required]
            public string TitleCs { get; set; }

            [Required]
            public string TitleEn { get; set; }

            [Required]
            public string DescriptionCs { get; set; }

            [Required]
            public string DescriptionEn { get; set; }

            public IFormFile? ImageUpload { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                responseViewModel = new ResponseViewModel
                {
                    IsSuccess = false,
                    Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()
                };
                return Page();
            }

            string? imageUrl = null;
            if (Input.ImageUpload != null)
            {
                imageUrl = await _imageService.UploadImageAsync(Input.ImageUpload, "gameideas");
            }

            var idea = GameIdea.Create(Input.TitleCs, Input.TitleEn, Input.DescriptionCs, Input.DescriptionEn, imageUrl);
            await _service.CreateAsync(idea);

            responseViewModel = new ResponseViewModel
            {
                IsSuccess = true,
                SuccessMessage = "Námět na hru byl úspěšně přidán."
            };
            Input = new InputModel();
            return Page();
        }
    }
}
