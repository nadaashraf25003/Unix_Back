using Microsoft.EntityFrameworkCore;
using Unix.Data.Modules.Content.DTOs;
using Unix.Data.Services.Interfaces.IServices.Content;

namespace Unix.Data.Services.Implementations.Services.Content
{
    public class NotificationsService : INotificationsService
    {
        private readonly AppDbContext _context;
        public NotificationsService(AppDbContext context) => _context = context;

        public async Task<List<NotificationDto>> GetUserNotificationsAsync(long userId) =>
            await _context.Notifications
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.CreatedAt)
                .Select(n => new NotificationDto
                {
                    Id = n.Id,
                    Message = n.Message,
                    IsRead = n.IsRead,
                    CreatedAt = n.CreatedAt
                }).ToListAsync();

        public async Task MarkAsReadAsync(long id)
        {
            var notification = await _context.Notifications.FindAsync(id)
                ?? throw new Exception("Notification not found");
            notification.IsRead = true;
            await _context.SaveChangesAsync();
        }
    }

}
