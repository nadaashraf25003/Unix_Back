using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unix.Data.Services.Interfaces.IServices.Campus;

namespace Unix.Controllers
{
    [ApiController]
    [Route("tables")]
    public class TablesController : ControllerBase
    {
        private readonly ICampusService _service;
        public TablesController(ICampusService service) => _service = service;

        [HttpGet("room/{roomId}")]
        public async Task<IActionResult> GetByRoom(int roomId) => Ok(await _service.GetTablesByRoomAsync(roomId));

        [HttpPost("occupy")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> Occupy(int tableId)
        {
            await _service.OccupyTableAsync(tableId);
            return Ok();
        }

        [HttpPost("release")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> Release(int tableId)
        {
            await _service.ReleaseTableAsync(tableId);
            return Ok();
        }
    }

}
