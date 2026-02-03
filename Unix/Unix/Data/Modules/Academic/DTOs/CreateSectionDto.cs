namespace Unix.Data.Modules.Academic.DTOs
{
    public class CreateSectionDto
    {
        public int DepartmentId { get; set; }
        public int Stage { get; set; }
        public string Name { get; set; } = null!;
    }

}
