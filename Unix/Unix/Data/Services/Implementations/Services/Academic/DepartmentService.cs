using Microsoft.EntityFrameworkCore;
using Unix.Data.Models.Academic;
using Unix.Data.Modules.Academic.DTOs;
using Unix.Data.Services.Interfaces.IServices.Academic;

namespace Unix.Data.Services.Implementations.Services.Academic
{
    public class DepartmentService : IDepartmentService
    {
        private readonly AppDbContext _context;

        public DepartmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<DepartmentDto>> GetAllAsync()
        {
            return await _context.Departments
                .Select(d => new DepartmentDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    Code = d.Code
                })
                .ToListAsync();
        }

        public async Task CreateAsync(CreateDepartmentDto dto)
        {
            _context.Departments.Add(new Department
            {
                Name = dto.Name,
                Code = dto.Code
            });

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, CreateDepartmentDto dto)
        {
            var dept = await _context.Departments.FindAsync(id)
                ?? throw new Exception("Department not found");

            dept.Name = dto.Name;
            dept.Code = dto.Code;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var dept = await _context.Departments.FindAsync(id)
                ?? throw new Exception("Department not found");

            _context.Departments.Remove(dept);
            await _context.SaveChangesAsync();
        }
    }

}
