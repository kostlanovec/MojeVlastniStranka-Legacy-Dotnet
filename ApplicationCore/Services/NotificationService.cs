using Microsoft.EntityFrameworkCore;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Entities;

namespace MojeVlastniStranka.ApplicationCore.Services
{
	public class NotificationService
	{
		private readonly DataContext context;

		public NotificationService(DataContext context)
		{
			this.context = context;
		}

		public void CreateNotification(string shortmessage)
		{
			var notification = Notification.Create(
				null,
				DateTime.Now,
				shortmessage
			);
			context.Notifications.Add(notification);
			context.SaveChangesAsync();
		}

		public async Task<List<NotificationDto>> GetAllNotification()
		{
			var result = await context.Notifications
				.Select(bp => new NotificationDto()
				{
					Id = bp.Id,
					ShortMessage = bp.ShortMessage
				})
				.ToListAsync();

			return result;
		}
	}
}
