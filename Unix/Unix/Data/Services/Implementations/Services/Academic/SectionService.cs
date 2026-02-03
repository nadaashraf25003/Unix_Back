using Microsoft.EntityFrameworkCore;
using Unix.Data.Models.Academic;
using Unix.Data.Modules.Academic.DTOs;
using Unix.Data.Services.Interfaces.IServices.Academic;

namespace Unix.Data.Services.Implementations.Services.Academic
{
    public class SectionService : ISectionService
    {
        private readonly AppDbContext _context;

        public SectionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<SectionDto>> GetAllAsync()
        {
            return await _context.Sections
                .Select(s => new SectionDto
                {
                    Id = s.Id,
                    DepartmentId = s.DepartmentId,
                    Stage = s.Stage,
                    Name = s.Name
                })
                .ToListAsync();
        }

        public async Task<List<SectionDto>> GetByDepartmentAsync(int departmentId)
        {
            return await _context.Sections
                .Where(s => s.DepartmentId == departmentId)
                .Select(s => new SectionDto
                {
                    Id = s.Id,
                    DepartmentId = s.DepartmentId,
                    Stage = s.Stage,
                    Name = s.Name
                })
                .ToListAsync();
        }

        public async Task CreateAsync(CreateSectionDto dto)
        {
            _context.Sections.Add(new Section
            {
                DepartmentId = dto.DepartmentId,
                Stage = dto.Stage,
                Name = dto.Name
            });

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, CreateSectionDto dto)
        {
            var section = await _context.Sections.FindAsync(id)
                ?? throw new Exception("Section not found");

            section.DepartmentId = dto.DepartmentId;
            section.Stage = dto.Stage;
            section.Name = dto.Name;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var section = await _context.Sections.FindAsync(id)
                ?? throw new Exception("Section not found");

            _context.Sections.Remove(section);
            await _context.SaveChangesAsync();
        }
    }

}
