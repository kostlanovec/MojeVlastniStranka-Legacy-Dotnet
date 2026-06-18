#nullable disable
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Requests;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess;

namespace MojeVlastniStranka.User.Areas.Admin.Pages.Development
{
	[Authorize]
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
		public ReportedBugRequest ReportedBugRequestBinding { get; set; }

		public string SuccessMessage { get; private set; }

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				// Pokud validace selže
				return Page();
			}

			var processingResult = await developmentService.ReportBug(ReportedBugRequestBinding);

			if (processingResult)
			{
				// to-do to by se mělo "načíst" z ApplicationCore.
				SuccessMessage = "Operace byla úspěšná.";

				return Page();
			}

			// Pokud zpracování bugu selže
			return Page();
		}
	}
}