using Unix.Data.Modules.Academic.DTOs;
using Unix.Data.Modules.Campus.DTOs;
using Unix.Data.Modules.Content.DTOs;
using Unix.Data.Modules.Projects.DTOs;

namespace Unix.Data.Modules.Dashboard.DTOs
{
    public class StudentDashboardDto
    {
        public List<ScheduleDto> Schedules { get; set; } = new();
        public List<ExamDto> Exams { get; set; } = new();
        public List<StageDriverDto> StageMaterials { get; set; } = new();
        public List<GraduationProjectDto> Projects { get; set; } = new();
        public List<NotificationDto> Notifications { get; set; } = new();
        public List<RoomAvailabilityDto> FreeRooms { get; set; } = new();
        public List<TableDto> FreeTables { get; set; } = new();
    }

}
