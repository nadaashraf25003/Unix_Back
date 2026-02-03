using Unix.Data.Modules.Content.DTOs;

namespace Unix.Data.Services.Interfaces.IServices.Content
{
    public interface INotificationsService
    {
        Task<List<NotificationDto>> GetUserNotificationsAsync(long userId);
        Task MarkAsReadAsync(long id);
    }

}
