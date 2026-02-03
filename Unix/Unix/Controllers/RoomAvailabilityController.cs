using Microsoft.AspNetCore.Mvc;
using Unix.Data.Services.Interfaces.IServices.Campus;

namespace Unix.Controllers
{
    [ApiController]
    [Route("rooms/availability")]
    public class RoomAvailabilityController : ControllerBase
    {
        private readonly ICampusService _service;
        public RoomAvailabilityController(ICampusService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.GetRoomAvailabilityAsync());
    }

}
