namespace Unix.Data.Modules.Academic.DTOs
{
    public class ExamDto
    {
        public long Id { get; set; }

        public string CourseName { get; set; } = null!;
        public string ExamType { get; set; } = null!;

        public string RoomCode { get; set; } = null!;
        public string? InstructorName { get; set; }

        public DateTime ExamDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }

}
