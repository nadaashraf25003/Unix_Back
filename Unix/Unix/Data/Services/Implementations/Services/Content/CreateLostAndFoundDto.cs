namespace Unix.Data.Services.Implementations.Services.Content
{
    public class CreateLostAndFoundDto
    {
        public string ItemName { get; set; } = null!;
        public string ItemType { get; set; } = null!;
        public string Location { get; set; } = null!;
        public DateOnly Date { get; set; }
        public string ContactInfo { get; set; } = null!;
    }

}
