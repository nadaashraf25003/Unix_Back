namespace Unix.Data.Models.Projects
{
    public class GraduationProject
    {
        public long Id { get; set; }
        public string ProjectName { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ICollection<ProjectMember> Members { get; set; } = new List<ProjectMember>();
    }

}
