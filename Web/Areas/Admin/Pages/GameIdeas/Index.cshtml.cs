using MojeVlastniStranka.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;

namespace MojeVlastniStranka.Web.Areas.Admin.Pages.GameIdeas
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IGameIdeaService _service;

        public IndexModel(IGameIdeaService service)
        {
            _service = service;
        }

        public List<GameIdea> GameIdeas { get; set; } = new List<GameIdea>();

        public async Task OnGetAsync()
        {
            GameIdeas = await _service.GetAllAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);
            return RedirectToPage();
        }
    }
}
