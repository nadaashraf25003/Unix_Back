using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unix.Data.Services.Interfaces.IServices.Logs;

namespace Unix.Controllers
{
    [ApiController]
    [Route("audit-logs")]
    [Authorize(Roles = "Admin")]
    public class AuditLogsController : ControllerBase
    {
        private readonly IAuditLogService _service;
        public AuditLogsController(IAuditLogService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.GetAllAsync());
    }

}
