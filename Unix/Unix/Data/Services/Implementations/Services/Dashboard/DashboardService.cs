using Microsoft.EntityFrameworkCore;
using Unix.Data.Modules.Academic.DTOs;
using Unix.Data.Modules.Campus.DTOs;
using Unix.Data.Modules.Content.DTOs;
using Unix.Data.Modules.Dashboard.DTOs;
using Unix.Data.Modules.Projects.DTOs;
using Unix.Data.Services.Implementations.Services.Content;
using Unix.Data.Services.Interfaces.IServices.Dashboard;

namespace Unix.Data.Services.Implementations.Services.Dashboard
{
    public class DashboardService : IDashboardService
    {
        private readonly AppDbContext _context;

        public DashboardService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<StudentDashboardDto> GetStudentDashboardAsync(long userId)
        {
            var student = await _context.Students
                .Include(s => s.StudentProfiles)
                .ThenInclude(sp => sp.Section)
                .Include(s => s.ProjectMembers)
                .ThenInclude(pm => pm.Project)
                .Include(s => s.User)
                .FirstOrDefaultAsync(s => s.UserId == userId);

            if (student == null) return new StudentDashboardDto();

            var sectionId = student.StudentProfiles.FirstOrDefault()?.SectionId ?? 0;

            // Schedules
            var schedules = await _context.Schedules
                .Where(s => s.SectionId == sectionId)
                .Include(s => s.Course)
                .Include(s => s.Room)
                .Select(s => new ScheduleDto
                {
                    CourseName = s.Course.CourseName,
                    RoomCode = s.Room.RoomCode,
                    DayOfWeek = s.DayOfWeek,
                    StartTime = s.StartTime,
                    EndTime = s.EndTime
                }).ToListAsync();

            // Exams
            var exams = await _context.Exams
                .Where(e => e.SectionId == sectionId && e.Stage == student.Stage)
                .Include(e => e.Course)
                .Include(e => e.Room)
                .Include(e => e.Instructor)
                .Select(e => new ExamDto
                {
                    Id = e.Id,
                    CourseName = e.Course.CourseName,
                    ExamType = e.ExamType,
                    RoomCode = e.Room.RoomCode,
                    InstructorName = e.Instructor != null ? e.Instructor.FullName : null,
                    ExamDate = e.ExamDate,
                    StartTime = e.StartTime,
                    EndTime = e.EndTime
                }).ToListAsync();

            // Stage Materials
            var stageMaterials = await _context.StageDrivers
                .Where(sd => sd.Stage == student.Stage && (sd.DepartmentId == student.DepartmentId || sd.DepartmentId == null))
                .Select(sd => new StageDriverDto
                {
                    Id = sd.Id,
                    Title = sd.Title,
                    Type = sd.Type,
                    Link = sd.Link
                }).ToListAsync();

            // Projects
            var projects = student.ProjectMembers
                .Select(pm => new GraduationProjectDto
                {
                    Id = pm.Project.Id,
                    ProjectName = pm.Project.ProjectName
                }).ToList();

            // Notifications
            var notifications = await _context.Notifications
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.CreatedAt)
                .Select(n => new NotificationDto
                {
                    Id = n.Id,
                    Message = n.Message,
                    IsRead = n.IsRead,
                    CreatedAt = n.CreatedAt
                }).ToListAsync();

            // Free rooms
            var freeRooms = await _context.RoomAvailabilities
                .Where(r => r.IsAvailable)
                .Select(r => new RoomAvailabilityDto
                {
                    RoomId = r.RoomId,
                    DayOfWeek = r.DayOfWeek,
                    StartTime = r.StartTime,
                    EndTime = r.EndTime,
                    IsAvailable = r.IsAvailable
                }).ToListAsync();

            // Free tables
            var freeTables = await _context.TableUsageHistories
                .Where(t => t.EndTime < DateTime.UtcNow)
                .Select(t => new TableDto
                {
                    Id = t.TableId,
                    RoomId = t.Table.RoomId,
                    TableNumber = t.Table.TableNumber,
                    IsOccupied = false
                }).ToListAsync();

            return new StudentDashboardDto
            {
                Schedules = schedules,
                Exams = exams,
                StageMaterials = stageMaterials,
                Projects = projects,
                Notifications = notifications,
                FreeRooms = freeRooms,
                FreeTables = freeTables
            };
        }

        public async Task<AdminDashboardDto> GetAdminDashboardAsync()
        {
            var totalStudents = await _context.Students.CountAsync();
            var totalCourses = await _context.Courses.CountAsync();
            var totalProjects = await _context.GraduationProjects.CountAsync();

            var freeRooms = await _context.RoomAvailabilities
                .Where(r => r.IsAvailable)
                .Select(r => new RoomAvailabilityDto
                {
                    RoomId = r.RoomId,
                    DayOfWeek = r.DayOfWeek,
                    StartTime = r.StartTime,
                    EndTime = r.EndTime,
                    IsAvailable = r.IsAvailable
                }).ToListAsync();

            var pendingMaintenance = await _context.MaintenanceRequests
                .Where(m => m.Status != "Resolved")
                .Select(m => new MaintenanceRequestDto
                {
                    Id = m.Id,
                    RoomId = m.RoomId,
                    Issue = m.Issue,
                    Status = m.Status,
                    ReportedById = m.ReportedById,
                    CreatedAt = m.CreatedAt
                }).ToListAsync();

            var activeLostAndFound = await _context.LostAndFoundItems
                .Where(l => !l.IsResolved)
                .Select(l => new LostAndFoundDto
                {
                    Id = l.Id,
                    ItemName = l.ItemName,
                    Location = l.Location,
                    Date = l.Date,
                    ContactInfo = l.ContactInfo
                }).ToListAsync();

            var notifications = await _context.Notifications
                .OrderByDescending(n => n.CreatedAt)
                .Select(n => new NotificationDto
                {
                    Id = n.Id,
                    Message = n.Message,
                    IsRead = n.IsRead,
                    CreatedAt = n.CreatedAt
                }).ToListAsync();

            return new AdminDashboardDto
            {
                TotalStudents = totalStudents,
                TotalCourses = totalCourses,
                TotalProjects = totalProjects,
                FreeRooms = freeRooms,
                PendingMaintenance = pendingMaintenance,
                ActiveLostAndFound = activeLostAndFound,
                Notifications = notifications
            };
        }
    }

}
