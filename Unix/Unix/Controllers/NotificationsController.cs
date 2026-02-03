using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unix.Data.Services.Interfaces.IServices.Content;

namespace Unix.Controllers
{
    [ApiController]
    [Route("notifications")]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationsService _service;
        public NotificationsController(INotificationsService service) => _service = service;

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var userId = long.Parse(User.FindFirst("id")!.Value);
            return Ok(await _service.GetUserNotificationsAsync(userId));
        }

        [HttpPut("{id}/read")]
        [Authorize]
        public async Task<IActionResult> MarkAsRead(long id)
        {
            await _service.MarkAsReadAsync(id);
            return Ok();
        }
    }

}
