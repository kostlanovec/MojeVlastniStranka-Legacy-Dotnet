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
			var notification = Notification.Create(
				Guid.NewGuid(), 
				DateTime.Now,
				shortmessage
			);
			context.Notifications.Add(notification);
			context.SaveChangesAsync();
		}

		/// <summary>
		/// Smaže notifikaci na základě poskytnutého Id.
		/// </summary>
		public async Task<FormProcessingResult> DeleteNotification(Guid NotificationId)
		{
			var formProcessingResult = new FormProcessingResult();
			var existingNotification = await context.Notifications.SingleOrDefaultAsync(bp => bp.Id == NotificationId);
			if (existingNotification != null)
			{
				context.Remove(existingNotification);
				await context.SaveChangesAsync(); ;
			}
			return formProcessingResult;
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

		/// <summary>
		/// Vezme tři nejnovější notifikace.
		/// </summary>
		public async Task<List<NotificationDto>> GetThreeNotification()
		{
			var result = await context.Notifications
				.OrderByDescending(bp => bp.TimePublish)
				.Select(bp => new NotificationDto()
				{
					Id = bp.Id,
					ShortMessage = bp.ShortMessage
				})
				.Take(3)
				.ToListAsync();

			return result;
		}
	}
}
