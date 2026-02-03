using Unix.Data.Models.Academic;

namespace Unix.Data.Models.Content
{
    public class StageDriver
    {
        public long Id { get; set; }
        public int Stage { get; set; }
        public int? DepartmentId { get; set; }

        public string Title { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Link { get; set; } = null!;

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Department? Department { get; set; }
    }

}
