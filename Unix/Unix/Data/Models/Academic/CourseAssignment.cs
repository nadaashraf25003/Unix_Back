namespace Unix.Data.Models.Academic
{
    public class CourseAssignment
    {
        public long Id { get; set; }
        public int CourseId { get; set; }
        public int SectionId { get; set; }

        public Course Course { get; set; } = null!;
        public Section Section { get; set; } = null!;
   
}
}
