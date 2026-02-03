using Unix.Data.Modules.Academic.DTOs;

namespace Unix.Data.Services.Interfaces.IServices.Academic
{
    public interface IExamService
    {
        Task<List<ExamDto>> GetStudentExamsAsync(long userId);

        Task CreateAsync(CreateExamDto dto);
        Task UpdateAsync(long id, CreateExamDto dto);
        Task DeleteAsync(long id);
    }

}
