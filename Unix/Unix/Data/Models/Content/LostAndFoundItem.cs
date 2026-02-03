namespace Unix.Data.Models.Content
{
    public class LostAndFoundItem
    {
        public long Id { get; set; }
        public string ItemName { get; set; } = null!;
        public string ItemType { get; set; } = null!;
        public string Location { get; set; } = null!;
        public DateOnly Date { get; set; }
        public string ContactInfo { get; set; } = null!;
        public long ReportedById { get; set; }
        public bool IsResolved { get; set; }
    }
}
