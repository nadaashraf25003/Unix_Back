namespace Unix.Data.Modules.Academic.DTOs
{
    public class CreateInstructorDto
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int DepartmentId { get; set; }
    }

}
