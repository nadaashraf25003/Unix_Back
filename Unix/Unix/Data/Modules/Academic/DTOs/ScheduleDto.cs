namespace Unix.Data.Modules.Academic.DTOs
{
    public class ScheduleDto
    {
        public long Id { get; set; }

        public string CourseName { get; set; } = null!;
        public string CourseCode { get; set; } = null!;

        public string InstructorName { get; set; } = null!;
        public string RoomCode { get; set; } = null!;

        public string DayOfWeek { get; set; } = null!;
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }

}
