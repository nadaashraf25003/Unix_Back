namespace Unix.Data.Models.Content
{
    public class Announcement
    {
        public long Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public long CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
