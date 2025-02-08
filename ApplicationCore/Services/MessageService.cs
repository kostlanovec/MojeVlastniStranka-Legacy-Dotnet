using Microsoft.EntityFrameworkCore;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Entities;

namespace MojeVlastniStranka.ApplicationCore.Services
{
	internal class MessageService
	{
		private readonly DataContext context;

		public MessageService(DataContext context)
		{
			this.context = context;
		}

		/// <summary>
		/// Tvorba nové notifikace.
		/// </summary>
		public void CreateMessage(string shortmessage)
		{
			var notification = Notification.Create(
				DateTime.Now,
				shortmessage
			);
			context.Notifications.Add(notification);
			context.SaveChangesAsync();
		}

		/// <summary>
		/// Smaže notifikaci na základě poskytnutého Id.
		/// </summary>
		public async Task<FormProcessingResult> DeleteMessage(Guid NotificationId)
		{
			var formProcessingResult = new FormProcessingResult();
			var existingNotification = await context.Messages.SingleOrDefaultAsync(bp => bp.Id == NotificationId);
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
		public async Task<List<NotificationDto>> GetAllMessage()
		{
			var result = await context.Messages
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
		public async Task<List<NotificationDto>> GetThreeMessages()
		{
			var result = await context.Messages
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
