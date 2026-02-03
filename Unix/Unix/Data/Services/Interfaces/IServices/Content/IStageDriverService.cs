using Unix.Data.Modules.Content.DTOs;

namespace Unix.Data.Services.Interfaces.IServices.Content
{
    public interface IStageDriverService
    {
        Task<List<StageDriverDto>> GetStudentMaterialsAsync(long userId);

        Task CreateAsync(CreateStageDriverDto dto);
        Task UpdateAsync(long id, CreateStageDriverDto dto);
        Task DeleteAsync(long id);
    }

}
