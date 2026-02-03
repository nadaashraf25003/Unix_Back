namespace Unix.Data.Modules.Campus.DTOs
{
    public class TableDto
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public bool IsOccupied { get; set; }
        public long RoomId { get; set; }
    }

}
