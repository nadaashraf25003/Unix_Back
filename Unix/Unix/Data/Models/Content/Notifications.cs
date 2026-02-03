using Unix.Data.Models.Auth;

namespace Unix.Data.Models.Content
{
    public class Notifications
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Message { get; set; } = null!;
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }

        public User User { get; set; } = null!;
    }
}
