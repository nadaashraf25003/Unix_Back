using Unix.Data.Models.Auth;

namespace Unix.Data.Models.Academic
{
    public class AdminProfile
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public int? DepartmentId { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public User User { get; set; } = null!;
        public Department? Department { get; set; }
    }

}
