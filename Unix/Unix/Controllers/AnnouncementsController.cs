using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unix.Data.Modules.Content.DTOs;
using Unix.Data.Services.Interfaces.IServices.Content;

namespace Unix.Controllers
{
    [ApiController]
    [Route("announcements")]
    public class AnnouncementsController : ControllerBase
    {
        private readonly IAnnouncementsService _service;
        public AnnouncementsController(IAnnouncementsService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.GetAllAsync());

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateAnnouncementDto dto)
        {
            var userId = long.Parse(User.FindFirst("id")!.Value);
            await _service.CreateAsync(dto, userId);
            return Ok();
        }
    }

}
