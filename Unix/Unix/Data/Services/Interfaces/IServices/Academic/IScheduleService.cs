using Unix.Data.Modules.Academic.DTOs;

namespace Unix.Data.Services.Interfaces.IServices.Academic
{
    public interface IScheduleService
    {
        Task<List<ScheduleDto>> GetByStudentAsync(long userId);
        Task<List<ScheduleDto>> GetBySectionAsync(int sectionId);

        Task CreateAsync(CreateScheduleDto dto);
        Task UpdateAsync(long id, CreateScheduleDto dto);
        Task DeleteAsync(long id);
    }

}
