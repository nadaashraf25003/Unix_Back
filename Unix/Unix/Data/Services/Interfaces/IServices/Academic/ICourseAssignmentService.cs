using Unix.Data.Modules.Academic.DTOs;

namespace Unix.Data.Services.Interfaces.IServices.Academic
{
    public interface ICourseAssignmentService
    {
        Task AssignAsync(CourseAssignmentDto dto);
        Task<List<CourseDto>> GetBySectionAsync(int sectionId);
    }

}
