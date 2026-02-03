using Unix.Data.Static;

namespace Unix.Data.Models.Auth
{
    public class EmailVerificationCode
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole? Role { get; set; }
        public int Stage { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int DepartmentId { get; set; }


        public string Code { get; set; } = string.Empty;

        public DateTime ExpiryDate { get; set; }
        public bool IsUsed { get; set; } = false;
    }

}
