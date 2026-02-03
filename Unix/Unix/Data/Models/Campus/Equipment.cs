namespace Unix.Data.Models.Campus
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int RoomId { get; set; }
        public int Quantity { get; set; }
    }
}
