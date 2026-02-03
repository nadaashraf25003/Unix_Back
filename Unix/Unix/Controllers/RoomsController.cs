using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unix.Data.Modules.Campus.DTOs;
using Unix.Data.Services.Interfaces.IServices.Campus;

namespace Unix.Controllers
{
    [ApiController]
    [Route("rooms")]
    public class RoomsController : ControllerBase
    {
        private readonly ICampusService _service;
        public RoomsController(ICampusService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.GetRoomsAsync());

        [HttpGet("by-building/{buildingId}")]
        public async Task<IActionResult> GetByBuilding(int buildingId) =>
            Ok(await _service.GetRoomsByBuildingAsync(buildingId));

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(RoomDto dto)
        {
            await _service.CreateRoomAsync(dto);
            return Ok();
        }
    }

}
