namespace Unix.Data.Modules.Campus.DTOs
{
    public class RoomAvailabilityDto
    {
        public int RoomId { get; set; }
        public string DayOfWeek { get; set; } = null!;
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public bool IsAvailable { get; set; }
    }

}
