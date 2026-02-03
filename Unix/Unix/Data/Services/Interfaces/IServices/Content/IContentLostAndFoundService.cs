using Unix.Data.Services.Implementations.Services.Content;

namespace Unix.Data.Services.Interfaces.IServices.Content
{
    public interface IContentLostAndFoundService
    {
        Task<List<LostAndFoundDto>> GetAllAsync();
        Task CreateAsync(CreateLostAndFoundDto dto, long reportedById);
        Task ResolveAsync(long id);
        Task DeleteAsync(long id);
    }

}
