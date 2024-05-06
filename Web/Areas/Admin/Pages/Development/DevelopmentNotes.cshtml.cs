using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Entities;

namespace MojeVlastniStranka.User.Areas.Admin.Pages.Development
{
    public class DevelopmentNotesModel : PageModel
    {
	    private readonly DataContext context;
	    private readonly DevelopmentService developmentService;

	    public List<ReportedBugDto> ReportedBugDto
	    {
		    get;
		    set;
	    }

	    public List<IdeaToReleaseDto> IdeaToReleaseDto
	    {
		    get;
		    set;
	    }

		public DevelopmentNotesModel(DataContext context, DevelopmentService developmentService)
	    {
		    this.context = context;
		    this.developmentService = developmentService;
	    }

	    public async Task OnGetAsync()
	    {
		     ReportedBugDto = await developmentService.GetAllReports();
		     IdeaToReleaseDto = await developmentService.GetAllIdeas();

	    }

	    public async Task<IActionResult> OnPostDeleteBugAsync(int id)
	    {
		    await developmentService.DeleteBugAsync(id);
		    return RedirectToPage();
	    }

	    public async Task<IActionResult> OnPostDeleteIdeaAsync(int id)
	    {
		    await developmentService.DeleteIdeaAsync(id);
		    return RedirectToPage();
	    }

	}
}
