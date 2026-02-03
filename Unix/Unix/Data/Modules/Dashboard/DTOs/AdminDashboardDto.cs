using Unix.Data.Modules.Campus.DTOs;
using Unix.Data.Modules.Content.DTOs;
using Unix.Data.Services.Implementations.Services.Content;

namespace Unix.Data.Modules.Dashboard.DTOs
{
    public class AdminDashboardDto
    {
        public int TotalStudents { get; set; }
        public int TotalCourses { get; set; }
        public int TotalProjects { get; set; }
        public List<RoomAvailabilityDto> FreeRooms { get; set; } = new();
        public List<MaintenanceRequestDto> PendingMaintenance { get; set; } = new();
        public List<LostAndFoundDto> ActiveLostAndFound { get; set; } = new();
        public List<NotificationDto> Notifications { get; set; } = new();
    }

}
