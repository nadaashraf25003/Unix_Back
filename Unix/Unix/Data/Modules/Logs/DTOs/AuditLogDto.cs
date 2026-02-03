namespace Unix.Data.Modules.Logs.DTOs
{
    public class AuditLogDto
    {
        public long Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Action { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }

}
