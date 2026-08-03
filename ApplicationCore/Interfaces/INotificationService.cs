using MojeVlastniStranka.ApplicationCore.Interfaces;
using MojeVlastniStranka.ApplicationCore.Dto;
using MojeVlastniStranka.DataAccess;
using MojeVlastniStranka.DataAccess.Entities;

namespace MojeVlastniStranka.ApplicationCore.Interfaces
{
    public interface INotificationService
    {
		void CreateNotification(string shortmessage);
		Task<FormProcessingResult> DeleteNotification(Guid NotificationId);
		Task<List<NotificationDto>> GetAllNotification();
		Task<List<NotificationDto>> GetThreeNotification();
    }
}
