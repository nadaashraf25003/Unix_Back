using Unix.Data.Models.Campus;

namespace Unix.Data.Models.Academic
{
    public class Exam
    {
        public long Id { get; set; }
        public int CourseId { get; set; }
        public int SectionId { get; set; }
        public int RoomId { get; set; }
        public long? InstructorId { get; set; }

        public int Stage { get; set; }
        public DateTime ExamDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public string ExamType { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Course? Course { get; set; }
        public Section? Section { get; set; }
        public Room? Room { get; set; }
        public Instructor? Instructor { get; set; }

    }

}
