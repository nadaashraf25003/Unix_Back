using Microsoft.AspNetCore.Mvc;
using Unix.Data.Services.Interfaces.IServices.Campus;

namespace Unix.Controllers
{
    [ApiController]
    [Route("room-paths")]
    public class RoomPathsController : ControllerBase
    {
        private readonly ICampusNavigationService _service;
        public RoomPathsController(ICampusNavigationService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllPathsAsync());

        [HttpGet("from/{fromRoomId}/to/{toRoomId}")]
        public async Task<IActionResult> GetPath(int fromRoomId, int toRoomId) =>
            Ok(await _service.GetPathAsync(fromRoomId, toRoomId));
    }

}
