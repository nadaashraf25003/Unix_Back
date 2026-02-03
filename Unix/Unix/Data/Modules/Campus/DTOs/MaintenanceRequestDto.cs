namespace Unix.Data.Modules.Campus.DTOs
{
    public class MaintenanceRequestDto
    {
        public long Id { get; set; }
        public long ReportedById { get; set; }
        public int RoomId { get; set; }
        public string Issue { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; } = "Pending";
    }

}
