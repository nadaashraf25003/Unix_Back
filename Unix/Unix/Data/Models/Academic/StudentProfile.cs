namespace Unix.Data.Models.Academic
{
    public class StudentProfile
    {
        public long Id { get; set; }
        public long StudentId { get; set; }
        public int SectionId { get; set; }
        public string Semester { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Student Student { get; set; } = null!;
        public Section Section { get; set; } = null!;
    }
}
