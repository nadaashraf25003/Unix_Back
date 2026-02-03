using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unix.Data.Modules.Academic.DTOs;
using Unix.Data.Services.Interfaces.IServices.Academic;

namespace Unix.Controllers
{
    [ApiController]
    [Route("sections")]
    [Authorize(Roles = "Admin")]
    public class SectionsController : ControllerBase
    {
        private readonly ISectionService _service;

        public SectionsController(ISectionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _service.GetAllAsync());

        [HttpGet("by-department/{departmentId}")]
        public async Task<IActionResult> GetByDepartment(int departmentId)
            => Ok(await _service.GetByDepartmentAsync(departmentId));

        [HttpPost]
        public async Task<IActionResult> Create(CreateSectionDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateSectionDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }

}
