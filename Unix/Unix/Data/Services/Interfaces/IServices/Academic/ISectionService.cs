using Unix.Data.Modules.Academic.DTOs;

namespace Unix.Data.Services.Interfaces.IServices.Academic
{
    public interface ISectionService
    {
        Task<List<SectionDto>> GetAllAsync();
        Task<List<SectionDto>> GetByDepartmentAsync(int departmentId);
        Task CreateAsync(CreateSectionDto dto);
        Task UpdateAsync(int id, CreateSectionDto dto);
        Task DeleteAsync(int id);
    }

}
