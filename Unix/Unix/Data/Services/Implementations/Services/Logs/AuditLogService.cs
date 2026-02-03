using Microsoft.EntityFrameworkCore;
using Unix.Data.Modules.Logs.DTOs;
using Unix.Data.Services.Interfaces.IServices.Logs;

namespace Unix.Data.Services.Implementations.Services.Logs
{
    public class AuditLogService : IAuditLogService
    {
        private readonly AppDbContext _context;
        public AuditLogService(AppDbContext context) => _context = context;

        public async Task<List<AuditLogDto>> GetAllAsync() =>
            await _context.AuditLogs
                .Include(a => a.User)
                .OrderByDescending(a => a.CreatedAt)
                .Select(a => new AuditLogDto
                {
                    Id = a.Id,
                    UserName = a.User.Name,
                    Action = a.Action,
                    CreatedAt = a.CreatedAt
                }).ToListAsync();
    }

}
