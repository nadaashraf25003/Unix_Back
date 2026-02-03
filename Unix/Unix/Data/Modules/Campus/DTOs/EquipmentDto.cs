namespace Unix.Data.Modules.Campus.DTOs
{
    public class EquipmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Quantity { get; set; }
        public int RoomId { get; set; }
    }

}
