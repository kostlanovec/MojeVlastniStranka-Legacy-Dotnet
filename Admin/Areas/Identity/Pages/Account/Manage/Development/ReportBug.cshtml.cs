using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Requests;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess;

namespace MojeVlastniStranka.Admin.Areas.Identity.Pages.Account.Manage.Development
{
    public class ReportBugModel : PageModel
    {
		private readonly DataContext context;
		private readonly DevelopmentService developmentService;

		public ReportBugModel(DataContext context, DevelopmentService developmentService)
		{
			this.context = context;
			this.developmentService = developmentService;
		}

		[BindProperty]
		public ReportedBugRequest ReportedBugRequestBinding
		{
			get;
			set;
		}

		public string SuccessMessage
		{
			get;
			set;
		}


		[HttpPost]
        public async Task<IActionResult> OnPostAsync()
        {
	        var processingResult = await developmentService.ReportBug(ReportedBugRequestBinding);

	        if (processingResult == true)
	        {
		        // to-do to by se mělo "načíst" z ApplicationCore.
		        SuccessMessage = "Operace byla úspěšná.";

		        return Page();
	        }
	        else
	        {
		        return Page();
	        }
        }
	}
}
