namespace Unix.Data.Modules.Campus.DTOs
{
    public class RoomPathDto
    {
        public int Id { get; set; }
        public int FromRoomId { get; set; }
        public int ToRoomId { get; set; }
        public string PathDescription { get; set; } = null!;
    }

}
