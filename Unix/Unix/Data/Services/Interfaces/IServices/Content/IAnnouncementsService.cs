using Unix.Data.Modules.Content.DTOs;

namespace Unix.Data.Services.Interfaces.IServices.Content
{
    public interface IAnnouncementsService
    {
        Task<List<AnnouncementDto>> GetAllAsync();
        Task CreateAsync(CreateAnnouncementDto dto, long createdById);
    }

}
