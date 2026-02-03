using Microsoft.EntityFrameworkCore;
using Unix.Data.Models.Academic;
using Unix.Data.Modules.Academic.DTOs;
using Unix.Data.Services.Interfaces.IServices.Academic;

namespace Unix.Data.Services.Implementations.Services.Academic
{
    public class InstructorService : IInstructorService
    {
        private readonly AppDbContext _context;

        public InstructorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<InstructorDto>> GetAllAsync()
        {
            return await _context.Instructors
                .Select(i => new InstructorDto
                {
                    Id = i.Id,
                    FullName = i.FullName,
                    Email = i.Email,
                    DepartmentId = i.DepartmentId
                })
                .ToListAsync();
        }

        public async Task CreateAsync(CreateInstructorDto dto)
        {
            _context.Instructors.Add(new Instructor
            {
                FullName = dto.FullName,
                Email = dto.Email,
                DepartmentId = dto.DepartmentId
            });

            await _context.SaveChangesAsync();
        }
    }

}
