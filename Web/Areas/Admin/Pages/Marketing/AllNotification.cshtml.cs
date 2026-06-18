#nullable disable
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.ApplicationCore.Services;
using MojeVlastniStranka.DataAccess;

namespace MojeVlastniStranka.User.Areas.Admin.Pages.Marketing
{
	[Authorize]
	public class AllNotificationModel : PageModel
	{
		private readonly DataContext context;
		private readonly NotificationService notificationService;

		public List<NotificationDto> notificationDtos
		{
			get;
			set;
		}
		public AllNotificationModel(DataContext context, NotificationService notificationService)
		{
			this.context = context;
			this.notificationService = notificationService;
		}

		public async Task OnGetAsync()
		{
			notificationDtos = await notificationService.GetAllNotification();
		}
	}
}
