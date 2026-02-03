using System.Drawing;

namespace Unix.Data.Models.Campus
{
    public class Room
    {
        public int Id { get; set; }
        public int BuildingId { get; set; }
        public int FloorId { get; set; }

        public string RoomCode { get; set; } = null!;
        public string RoomType { get; set; } = null!;
        public int Capacity { get; set; }

        public Building Building { get; set; } = null!;
        public Floor Floor { get; set; } = null!;
    }

}
