#nullable disable
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Entities;

namespace MojeVlastniStranka.Web.Areas.Admin.Pages.Marketing
{
	public class ServicesTableModel : PageModel
	{
		private readonly DataContext context;
		private readonly ServicesOfferedService offeredService;

		public ServicesTableModel(DataContext context, ServicesOfferedService offeredService)
		{
			this.context = context;
			this.offeredService = offeredService;
		}

		public List<ServiceRequest> serviceRequests
		{
			get;
			set;
		}

		public void OnGet()
		{
			serviceRequests = offeredService.getAllServicesRequests();
		}
	}
}
