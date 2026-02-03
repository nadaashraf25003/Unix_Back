using Unix.Data.Models.Auth;

namespace Unix.Data.Models.Logs
{
    public class AuditLog
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Action { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        public User User { get; set; } = null!;
    }

}
