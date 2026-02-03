using Microsoft.EntityFrameworkCore;
using Unix.Data.Models.Content;
using Unix.Data.Modules.Content.DTOs;
using Unix.Data.Services.Interfaces.IServices.Content;

namespace Unix.Data.Services.Implementations.Services.Content
{
    public class StageDriverService : IStageDriverService
    {
        private readonly AppDbContext _context;

        public StageDriverService(AppDbContext context)
        {
            _context = context;
        }

        // STUDENT MATERIALS
        public async Task<List<StageDriverDto>> GetStudentMaterialsAsync(long userId)
        {
            var studentProfile = await _context.StudentProfiles
                .Include(sp => sp.Section)
                .ThenInclude(s => s.Department)
                .FirstOrDefaultAsync(sp => sp.Student.UserId == userId);

            if (studentProfile == null) return new List<StageDriverDto>();

            return await _context.StageDrivers
                .Where(sd => sd.Stage == studentProfile.Section.Stage &&
                             sd.DepartmentId == studentProfile.Section.DepartmentId)
                .Select(sd => new StageDriverDto
                {
                    Id = sd.Id,
                    Title = sd.Title,
                    Type = sd.Type,
                    Link = sd.Link,
                    Stage = sd.Stage,
                    DepartmentName = sd.Department != null ? sd.Department.Name : null
                })
                .ToListAsync();
        }

        // ADMIN / INSTRUCTOR CREATE
        public async Task CreateAsync(CreateStageDriverDto dto)
        {
            _context.StageDrivers.Add(new StageDriver
            {
                Title = dto.Title,
                Type = dto.Type,
                Link = dto.Link,
                Stage = dto.Stage,
                DepartmentId = dto.DepartmentId,
                CreatedAt = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();
        }

        // UPDATE
        public async Task UpdateAsync(long id, CreateStageDriverDto dto)
        {
            var driver = await _context.StageDrivers.FindAsync(id)
                ?? throw new Exception("StageDriver not found");

            driver.Title = dto.Title;
            driver.Type = dto.Type;
            driver.Link = dto.Link;
            driver.Stage = dto.Stage;
            driver.DepartmentId = dto.DepartmentId;
            driver.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }

        // DELETE
        public async Task DeleteAsync(long id)
        {
            var driver = await _context.StageDrivers.FindAsync(id)
                ?? throw new Exception("StageDriver not found");

            _context.StageDrivers.Remove(driver);
            await _context.SaveChangesAsync();
        }
    }

}
