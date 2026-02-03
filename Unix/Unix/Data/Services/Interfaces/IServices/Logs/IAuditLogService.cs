using Unix.Data.Modules.Logs.DTOs;

namespace Unix.Data.Services.Interfaces.IServices.Logs
{
    public interface IAuditLogService
    {
        Task<List<AuditLogDto>> GetAllAsync();
    }

}
