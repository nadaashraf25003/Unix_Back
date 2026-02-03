namespace Unix.Data.Modules.Content.DTOs
{
    public class StageDriverDto
    {
        public long Id { get; set; }
        public string Title { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Link { get; set; } = null!;
        public int Stage { get; set; }
        public string? DepartmentName { get; set; }
    }

}
