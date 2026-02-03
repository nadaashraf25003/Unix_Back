namespace Unix.Data.Models.Academic
{
    public class InstructorCourse
    {
        public long Id { get; set; }
        public long InstructorId { get; set; }
        public int CourseId { get; set; }

        public Instructor Instructor { get; set; } = null!;
        public Course Course { get; set; } = null!;
    }
}
