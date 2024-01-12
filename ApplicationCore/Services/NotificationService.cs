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

		/// <summary>
		/// Tvorba nové notifikace.
		/// </summary>
		public void CreateNotification(string shortmessage)
		{
#if DEBUG
			var notification = Notification.Create(
				null,
				DateTime.Now,
				shortmessage
			);
#else
			var notification = Notification.Create(
				DateTime.Now,
				shortmessage
			);
#endif
			context.Notifications.Add(notification);
			context.SaveChangesAsync();
		}

		/// <summary>
		/// Získání všech notifikací.
		/// </summary>
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
