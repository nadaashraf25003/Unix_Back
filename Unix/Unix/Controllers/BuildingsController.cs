using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unix.Data.Modules.Campus.DTOs;
using Unix.Data.Services.Interfaces.IServices.Campus;

namespace Unix.Controllers
{
    [ApiController]
    [Route("buildings")]
    public class BuildingsController : ControllerBase
    {
        private readonly ICampusService _service;
        public BuildingsController(ICampusService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.GetBuildingsAsync());

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(BuildingDto dto)
        {
            await _service.CreateBuildingAsync(dto);
            return Ok();
        }
    }

}
