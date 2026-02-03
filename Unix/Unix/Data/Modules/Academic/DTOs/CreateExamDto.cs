namespace Unix.Data.Modules.Academic.DTOs
{
    public class CreateExamDto
    {
        public int CourseId { get; set; }
        public int SectionId { get; set; }
        public int RoomId { get; set; }
        public long? InstructorId { get; set; }

        public int Stage { get; set; }
        public DateTime ExamDate { get; set; }

        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public string ExamType { get; set; } = null!;
    }

}
