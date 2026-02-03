namespace Unix.Data.Modules.Content.DTOs
{
    public class CreateStageDriverDto
    {
        public string Title { get; set; } = null!;
        public string Type { get; set; } = null!; // PDF / Video / Link
        public string Link { get; set; } = null!;
        public int Stage { get; set; }
        public int? DepartmentId { get; set; }
    }

}
