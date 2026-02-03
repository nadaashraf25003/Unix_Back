namespace Unix.Data.Modules.Academic.DTOs
{
    public class InstructorDto
    {
        public long Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int DepartmentId { get; set; }
    }

}
