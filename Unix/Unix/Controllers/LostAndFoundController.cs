using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unix.Data.Services.Implementations.Services.Content;
using Unix.Data.Services.Interfaces.IServices.Content;

namespace Unix.Controllers
{
    [ApiController]
    [Route("lost-found")]
    public class LostAndFoundController : ControllerBase
    {
        private readonly IContentLostAndFoundService _service;
        public LostAndFoundController(IContentLostAndFoundService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.GetAllAsync());

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateLostAndFoundDto dto)
        {
            var userId = long.Parse(User.FindFirst("id")!.Value);
            await _service.CreateAsync(dto, userId);
            return Ok();
        }

        [HttpPut("{id}/resolve")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Resolve(long id)
        {
            await _service.ResolveAsync(id);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(long id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }

}
