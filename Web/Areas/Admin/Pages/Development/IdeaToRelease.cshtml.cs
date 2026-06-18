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
	public class IdeaToReleaseModel : PageModel
	{
		private readonly DataContext context;
		private readonly DevelopmentService developmentService;

		public IdeaToReleaseModel(DataContext context, DevelopmentService developmentService)
		{
			this.context = context;
			this.developmentService = developmentService;
		}

		[BindProperty]
		public IdeaToReleaseRequest IdeaToReleaseRequestBinding
		{
			get;
			set;
		}

		public string SuccessMessage
		{
			get;
			set;
		}

		public async Task<IActionResult> OnPostAsync()
		{
			var processingResult = await developmentService.AddIdeaToRelease(IdeaToReleaseRequestBinding);

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
