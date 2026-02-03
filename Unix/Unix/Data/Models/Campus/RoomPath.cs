namespace Unix.Data.Models.Campus
{
    public class RoomPath
    {
        public int Id { get; set; }
        public int FromRoomId { get; set; }
        public int ToRoomId { get; set; }
        public string PathDescription { get; set; } = null!;
    }
}
