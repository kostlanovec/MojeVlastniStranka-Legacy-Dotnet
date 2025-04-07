using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.Common.Models;
using MojeVlastniStranka.DataAccess;

namespace MojeVlastniStranka.User.Areas.Admin.Pages.Account.Manage
{
	[Authorize]
	public class IndexModel : PageModel
	{
		private readonly DataContext context;
		private readonly DashboardService dashboardService;

		public IndexModel(DataContext context, DashboardService dashboardService)
		{
			this.context = context;
			this.dashboardService = dashboardService;
		}

		/// <summary>
		/// Získá poèet vyplìných kontaktních formuláøù
		/// </summary>
		public int NumberOfContactForms
		{
			get;
			set;
		}

		/// <summary>
		/// Získá poèet blogových pøíspìvkù.
		/// </summary>
		public int NumberOfBlogPosts
		{
			get;
			set;
		}

		public int NumberOfServicesRequest
		{
			get;
			set;
		}

		public List<GraphMainServicesModel> MainServicesDataModel
		{
			get;
			set;
		}

		/// <summary>
		/// Získá poèet vyplìných kontaktních formuláøù a poèet blogových pøíspìvkù.
		/// </summary>
		/// <returns></returns>
		public async Task OnGetAsync()
		{
			NumberOfContactForms = await dashboardService.NumberOfContactForms();
			NumberOfBlogPosts = await dashboardService.NumberOfBlogPosts();
			NumberOfServicesRequest = await dashboardService.NumberOfServices();
			MainServicesDataModel = await dashboardService.NumberOfServicesPerMainServices();
			// todo vzít data pro graf pro návštěvnost z api.
		}
	}
}
