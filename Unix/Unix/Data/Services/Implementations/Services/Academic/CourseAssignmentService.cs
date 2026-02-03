using Microsoft.EntityFrameworkCore;
using Unix.Data.Models.Academic;
using Unix.Data.Modules.Academic.DTOs;
using Unix.Data.Services.Interfaces.IServices.Academic;

namespace Unix.Data.Services.Implementations.Services.Academic
{
    public class CourseAssignmentService : ICourseAssignmentService
    {
        private readonly AppDbContext _context;

        public CourseAssignmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AssignAsync(CourseAssignmentDto dto)
        {
            _context.CourseAssignments.Add(new CourseAssignment
            {
                CourseId = dto.CourseId,
                SectionId = dto.SectionId
            });

            await _context.SaveChangesAsync();
        }

        public async Task<List<CourseDto>> GetBySectionAsync(int sectionId)
        {
            return await _context.CourseAssignments
                .Where(ca => ca.SectionId == sectionId)
                .Select(ca => new CourseDto
                {
                    Id = ca.Course.Id,
                    CourseName = ca.Course.CourseName,
                    CourseCode = ca.Course.CourseCode
                })
                .ToListAsync();
        }
    }

}
