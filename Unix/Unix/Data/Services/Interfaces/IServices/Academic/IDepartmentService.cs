using Unix.Data.Modules.Academic.DTOs;

namespace Unix.Data.Services.Interfaces.IServices.Academic
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDto>> GetAllAsync();
        Task CreateAsync(CreateDepartmentDto dto);
        Task UpdateAsync(int id, CreateDepartmentDto dto);
        Task DeleteAsync(int id);
    }
}

