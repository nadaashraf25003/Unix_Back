namespace Unix.Data.Models.Academic
{
    public class StudentSection
    {
        public long Id { get; set; }
        public long StudentId { get; set; }
        public int SectionId { get; set; }

        public Student Student { get; set; } = null!;
        public Section Section { get; set; } = null!;
    }

}
