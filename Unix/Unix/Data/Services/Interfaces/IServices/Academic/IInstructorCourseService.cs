using Unix.Data.Modules.Academic.DTOs;

namespace Unix.Data.Services.Interfaces.IServices.Academic
{
    public interface IInstructorCourseService
    {
        Task AssignAsync(InstructorCourseDto dto);
        Task<List<CourseDto>> GetByCourseAsync(int courseId);
    }

}
