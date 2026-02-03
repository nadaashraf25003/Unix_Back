namespace Unix.Data.Modules.Content.DTOs
{
    public class AnnouncementDto
    {
        public long Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public long CreatedById { get; set; }
    }

}
