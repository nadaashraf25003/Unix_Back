using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unix.Data.Models.Auth;
using Unix.Data.Modules.Content.DTOs;
using Unix.Data.Services.Interfaces.IServices.Content;

namespace Unix.Controllers
{
    [ApiController]
    [Route("stage-drivers")]
    public class StageDriversController : ControllerBase
    {
        private readonly IStageDriverService _service;

        public StageDriversController(IStageDriverService service)
        {
            _service = service;
        }

        // STUDENT VIEW
        [HttpGet("student")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetStudentMaterials()
        {
            var userId = long.Parse(User.FindFirst("id")!.Value);
            var materials = await _service.GetStudentMaterialsAsync(userId);
            return Ok(materials);
        }

        // ADMIN / INSTRUCTOR ACTIONS
        [HttpPost]
        [Authorize(Roles = "Admin,Instructor")]
        public async Task<IActionResult> Create(CreateStageDriverDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Instructor")]
        public async Task<IActionResult> Update(long id, CreateStageDriverDto dto)
        {
            await _service.UpdateAsync(id, dto);
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
