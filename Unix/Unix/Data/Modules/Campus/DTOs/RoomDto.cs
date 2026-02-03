namespace Unix.Data.Modules.Campus.DTOs
{
    public class RoomDto
    {
        public int Id { get; set; }
        public string RoomCode { get; set; } = null!;
        public string RoomType { get; set; } = null!;
        public int Capacity { get; set; }
        public int BuildingId { get; set; }
        public int FloorId { get; set; }
    }

}
