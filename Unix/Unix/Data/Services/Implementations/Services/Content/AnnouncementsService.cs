using Microsoft.EntityFrameworkCore;
using Unix.Data.Models.Content;
using Unix.Data.Modules.Content.DTOs;
using Unix.Data.Services.Interfaces.IServices.Content;

namespace Unix.Data.Services.Implementations.Services.Content
{
    public class AnnouncementsService : IAnnouncementsService
    {
        private readonly AppDbContext _context;
        public AnnouncementsService(AppDbContext context) => _context = context;

        public async Task<List<AnnouncementDto>> GetAllAsync() =>
            await _context.Announcements
                .Include(a => a.CreatedById)
                .OrderByDescending(a => a.CreatedAt)
                .Select(a => new AnnouncementDto
                {
                    Id = a.Id,
                    Title = a.Title,
                    Content = a.Content,
                    CreatedAt = a.CreatedAt,
                    CreatedById = a.CreatedById,
                }).ToListAsync();

        public async Task CreateAsync(CreateAnnouncementDto dto, long createdById)
        {
            _context.Announcements.Add(new Announcement
            {
                Title = dto.Title,
                Content = dto.Content,
                CreatedById = createdById,
                CreatedAt = DateTime.UtcNow
            });
            await _context.SaveChangesAsync();
        }
    }

}
