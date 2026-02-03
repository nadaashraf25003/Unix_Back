using Microsoft.EntityFrameworkCore;
using Unix.Data.Models.Academic;
using Unix.Data.Modules.Academic.DTOs;
using Unix.Data.Services.Interfaces.IServices.Academic;

namespace Unix.Data.Services.Implementations.Services.Academic
{
    public class ScheduleService : IScheduleService
    {
        private readonly AppDbContext _context;

        public ScheduleService(AppDbContext context)
        {
            _context = context;
        }

        // STUDENT SCHEDULE
        public async Task<List<ScheduleDto>> GetByStudentAsync(long userId)
        {
            var sectionId = await _context.StudentProfiles
                .Where(sp => sp.Student.UserId == userId)
                .Select(sp => sp.SectionId)
                .FirstOrDefaultAsync();

            if (sectionId == 0)
                return new List<ScheduleDto>();

            return await GetBySectionAsync(sectionId);
        }

        // SECTION SCHEDULE
        public async Task<List<ScheduleDto>> GetBySectionAsync(int sectionId)
        {
            return await _context.Schedules
                .Where(s => s.SectionId == sectionId)
                .OrderBy(s => s.DayOfWeek)
                .ThenBy(s => s.StartTime)
                .Select(s => new ScheduleDto
                {
                    Id = s.Id,
                    CourseName = s.Course.CourseName,
                    CourseCode = s.Course.CourseCode,
                    InstructorName = s.Instructor.FullName,
                    RoomCode = s.Room.RoomCode,
                    DayOfWeek = s.DayOfWeek,
                    StartTime = s.StartTime,
                    EndTime = s.EndTime
                })
                .ToListAsync();
        }

        public async Task CreateAsync(CreateScheduleDto dto)
        {
            _context.Schedules.Add(new Schedule
            {
                CourseId = dto.CourseId,
                RoomId = dto.RoomId,
                SectionId = dto.SectionId,
                InstructorId = dto.InstructorId,
                DayOfWeek = dto.DayOfWeek,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime
            });

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(long id, CreateScheduleDto dto)
        {
            var schedule = await _context.Schedules.FindAsync(id)
                ?? throw new Exception("Schedule not found");

            schedule.CourseId = dto.CourseId;
            schedule.RoomId = dto.RoomId;
            schedule.SectionId = dto.SectionId;
            schedule.InstructorId = dto.InstructorId;
            schedule.DayOfWeek = dto.DayOfWeek;
            schedule.StartTime = dto.StartTime;
            schedule.EndTime = dto.EndTime;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var schedule = await _context.Schedules.FindAsync(id)
                ?? throw new Exception("Schedule not found");

            _context.Schedules.Remove(schedule);
            await _context.SaveChangesAsync();
        }
    }

}
