using Unix.Data.Modules.Academic.DTOs;

namespace Unix.Data.Services.Interfaces.IServices.Academic
{
    public interface ICoursesService
    {
        Task<List<CourseDto>> GetAllAsync();
        Task CreateAsync(CreateCourseDto dto);
        Task UpdateAsync(int id, CreateCourseDto dto);
        Task DeleteAsync(int id);
    }

}
