namespace Unix.Data.Models.Academic
{
    public class Instructor
    {
        public long Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int DepartmentId { get; set; }

        public Department Department { get; set; } = null!;
    }
}
