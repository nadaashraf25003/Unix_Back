namespace Unix.Data.Modules.Content.DTOs
{
    public class NotificationDto
    {
        public long Id { get; set; }
        public string Message { get; set; } = null!;
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
