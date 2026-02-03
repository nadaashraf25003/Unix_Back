namespace Unix.Data.Models.Campus
{
    public class RoomAvailability
    {
        public long Id { get; set; }
        public int RoomId { get; set; }
        public string DayOfWeek { get; set; } = null!;
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public bool IsAvailable { get; set; }
    }
}
