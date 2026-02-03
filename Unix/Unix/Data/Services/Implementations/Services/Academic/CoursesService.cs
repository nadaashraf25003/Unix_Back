using Microsoft.EntityFrameworkCore;
using Unix.Data.Models.Academic;
using Unix.Data.Modules.Academic.DTOs;
using Unix.Data.Services.Interfaces.IServices.Academic;

namespace Unix.Data.Services.Implementations.Services.Academic
{
    public class CoursesService : ICoursesService
    {
        private readonly AppDbContext _context;

        public CoursesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CourseDto>> GetAllAsync()
        {
            return await _context.Courses
                .Select(c => new CourseDto
                {
                    Id = c.Id,
                    CourseName = c.CourseName,
                    CourseCode = c.CourseCode
                })
                .ToListAsync();
        }

        public async Task CreateAsync(CreateCourseDto dto)
        {
            _context.Courses.Add(new Course
            {
                CourseName = dto.CourseName,
                CourseCode = dto.CourseCode
            });

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, CreateCourseDto dto)
        {
            var course = await _context.Courses.FindAsync(id)
                ?? throw new Exception("Course not found");

            course.CourseName = dto.CourseName;
            course.CourseCode = dto.CourseCode;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id)
                ?? throw new Exception("Course not found");

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }
    }

}
