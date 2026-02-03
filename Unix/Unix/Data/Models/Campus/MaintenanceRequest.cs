namespace Unix.Data.Models.Campus
{
    public class MaintenanceRequest
    {
        public long Id { get; set; }
        public int RoomId { get; set; }
        public string Issue { get; set; } = null!;
        public long ReportedById { get; set; }
        public string Status { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }

}
