using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unix.Data.Modules.Campus.DTOs;
using Unix.Data.Services.Interfaces.IServices.Campus;

namespace Unix.Controllers
{
    [ApiController]
    [Route("equipment")]
    public class EquipmentController : ControllerBase
    {
        private readonly ICampusService _service;
        public EquipmentController(ICampusService service) => _service = service;

        [HttpGet("room/{roomId}")]
        public async Task<IActionResult> GetByRoom(int roomId) => Ok(await _service.GetEquipmentByRoomAsync(roomId));

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(EquipmentDto dto)
        {
            await _service.AddEquipmentAsync(dto);
            return Ok();
        }
    }

}
