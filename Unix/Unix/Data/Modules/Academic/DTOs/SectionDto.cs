namespace Unix.Data.Modules.Academic.DTOs
{
    public class SectionDto
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int Stage { get; set; }
        public string Name { get; set; } = null!;
    }

}
