using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unix.Data.Modules.Campus.DTOs;
using Unix.Data.Services.Interfaces.IServices.Campus;

namespace Unix.Controllers
{
    [ApiController]
    [Route("maintenance")]
    public class MaintenanceController : ControllerBase
    {
        private readonly ICampusService _service;
        public MaintenanceController(ICampusService service) => _service = service;

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get() => Ok(await _service.GetMaintenanceRequestsAsync());

        [HttpPost]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> Create(MaintenanceRequestDto dto)
        {
            var userId = long.Parse(User.FindFirst("id")!.Value);
            await _service.CreateMaintenanceRequestAsync(dto, userId);
            return Ok();
        }

        [HttpPut("{id}/status")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateStatus(long id, [FromBody] string status)
        {
            await _service.UpdateMaintenanceStatusAsync(id, status);
            return Ok();
        }
    }

}
