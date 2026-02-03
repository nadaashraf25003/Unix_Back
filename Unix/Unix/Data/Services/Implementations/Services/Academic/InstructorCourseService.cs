using Microsoft.EntityFrameworkCore;
using Unix.Data.Models.Academic;
using Unix.Data.Modules.Academic.DTOs;
using Unix.Data.Services.Interfaces.IServices.Academic;

namespace Unix.Data.Services.Implementations.Services.Academic
{
    public class InstructorCourseService : IInstructorCourseService
    {
        private readonly AppDbContext _context;

        public InstructorCourseService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AssignAsync(InstructorCourseDto dto)
        {
            _context.InstructorCourses.Add(new InstructorCourse
            {
                InstructorId = dto.InstructorId,
                CourseId = dto.CourseId
            });

            await _context.SaveChangesAsync();
        }

        public async Task<List<CourseDto>> GetByCourseAsync(int courseId)
        {
            return await _context.InstructorCourses
                .Where(ic => ic.CourseId == courseId)
                .Select(ic => new CourseDto
                {
                    Id = ic.Course.Id,
                    CourseName = ic.Course.CourseName,
                    CourseCode = ic.Course.CourseCode
                })
                .ToListAsync();
        }
    }

}