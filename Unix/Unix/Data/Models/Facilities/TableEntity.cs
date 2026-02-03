namespace Unix.Data.Models.Facilities
{
    public class TableEntity
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int TableNumber { get; set; }
        public bool IsOccupied { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
