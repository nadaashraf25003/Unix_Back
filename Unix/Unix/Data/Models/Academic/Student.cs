using Unix.Data.Models.Auth;
using Unix.Data.Models.Projects;

namespace Unix.Data.Models.Academic
{
    public class Student
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public int DepartmentId { get; set; }
        public int Stage { get; set; }

        public User User { get; set; } = null!;
        public Department Department { get; set; } = null!;

        public ICollection<StudentSection> StudentSections { get; set; } = new List<StudentSection>();
        public ICollection<ProjectMember> ProjectMembers { get; set; } = new List<ProjectMember>();
        public ICollection<StudentProfile> StudentProfiles { get; set; } = new List<StudentProfile>();

    }

}
