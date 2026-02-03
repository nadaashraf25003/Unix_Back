namespace Unix.Data.Models.Academic
{
    public class Section
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int Stage { get; set; }
        public string Name { get; set; } = null!;

        public Department Department { get; set; } = null!;
        public ICollection<StudentProfile> StudentProfiles { get; set; } = new List<StudentProfile>();
        public ICollection<StudentSection> StudentSections { get; set; } = new List<StudentSection>();


    }

}
