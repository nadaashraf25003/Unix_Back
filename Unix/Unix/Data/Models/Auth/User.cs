using Unix.Data.Models.Academic;
using Unix.Data.Models.Content;
using Unix.Data.Models.Logs;
using Unix.Data.Static;

namespace Unix.Data.Models.Auth
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public UserRole? Role { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public Student? Student { get; set; }
        public AdminProfile? AdminProfile { get; set; }
         public int DepartmentId { get; set; }
        public int Stage { get; set; }

        public bool IsEmailVerified { get; set; }
        public ICollection<Notifications> Notifications { get; set; } = new List<Notifications>();
        public ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();
    }

}
