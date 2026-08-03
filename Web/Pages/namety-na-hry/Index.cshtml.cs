using MojeVlastniStranka.ApplicationCore.Interfaces;
#nullable disable
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.DataAccess.Entities;

namespace MojeVlastniStranka.Web.Pages.namety_na_hry
{
	public class IndexModel : PageModel
	{
		private readonly IGameIdeaService gameIdeaService;

		public IndexModel(IGameIdeaService gameIdeaService)
		{
			this.gameIdeaService = gameIdeaService;
		}

		public List<GameIdea> GameIdeas { get; set; }

		public async Task OnGetAsync()
		{
			GameIdeas = await gameIdeaService.GetAllAsync();
		}
	}
}
