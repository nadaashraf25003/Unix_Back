namespace Unix.Data.Services.Implementations.Services.Content
{
    public class LostAndFoundDto
    {
        public long Id { get; set; }
        public string ItemName { get; set; } = null!;
        public string ItemType { get; set; } = null!;
        public string Location { get; set; } = null!;
        public DateOnly Date { get; set; }
        public string ContactInfo { get; set; } = null!;
        public bool IsResolved { get; set; }
    }

}
