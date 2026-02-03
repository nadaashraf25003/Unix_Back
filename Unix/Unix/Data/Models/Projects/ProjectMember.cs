using Unix.Data.Models.Academic;

namespace Unix.Data.Models.Projects
{
    public class ProjectMember
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public long StudentId { get; set; }

        public DateTime CreatedAt { get; set; }

        public GraduationProject Project { get; set; } = null!;
        public Student Student { get; set; } = null!;
    }

}
