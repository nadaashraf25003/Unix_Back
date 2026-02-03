using Unix.Data.Models.Campus;

namespace Unix.Data.Models.Academic
{
    public class Schedule
    {
        public long Id { get; set; }
        public int CourseId { get; set; }
        public int RoomId { get; set; }
        public int SectionId { get; set; }
        public long InstructorId { get; set; }

        public string DayOfWeek { get; set; } = null!;
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public Course Course { get; set; } = null!;
        public Room Room { get; set; } = null!;
        public Section Section { get; set; } = null!;
        public Instructor Instructor { get; set; } = null!;
    }

}
