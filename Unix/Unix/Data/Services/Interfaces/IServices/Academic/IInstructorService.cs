using Unix.Data.Modules.Academic.DTOs;

namespace Unix.Data.Services.Interfaces.IServices.Academic
{
    public interface IInstructorService
    {
        Task<List<InstructorDto>> GetAllAsync();
        Task CreateAsync(CreateInstructorDto dto);
    }

}
