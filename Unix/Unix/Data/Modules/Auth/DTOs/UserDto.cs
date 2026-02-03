using Unix.Data.Static;

namespace Unix.Data.Modules.Auth.DTOs
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserRole? Role { get; set; } 
        public int DepartmentId { get; set; }
        public int Stage { get; set; }

    }
}
