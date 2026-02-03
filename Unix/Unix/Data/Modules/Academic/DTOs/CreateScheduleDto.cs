namespace Unix.Data.Modules.Academic.DTOs
{
    public class CreateScheduleDto
    {
        public int CourseId { get; set; }
        public int RoomId { get; set; }
        public int SectionId { get; set; }
        public long InstructorId { get; set; }

        public string DayOfWeek { get; set; } = null!;
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }

}
