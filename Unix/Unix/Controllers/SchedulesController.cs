using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unix.Data.Modules.Academic.DTOs;
using Unix.Data.Services.Interfaces.IServices.Academic;

namespace Unix.Controllers
{
    [ApiController]
    [Route("schedules")]
    public class SchedulesController : ControllerBase
    {
        private readonly IScheduleService _service;

        public SchedulesController(IScheduleService service)
        {
            _service = service;
        }

        // STUDENT VIEW
        [HttpGet("student")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetStudentSchedule()
        {
            var userId = long.Parse(User.FindFirst("id")!.Value);
            return Ok(await _service.GetByStudentAsync(userId));
        }

        // SECTION VIEW (Admin)
        [HttpGet("section/{sectionId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetBySection(int sectionId)
            => Ok(await _service.GetBySectionAsync(sectionId));

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateScheduleDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(long id, CreateScheduleDto dto)
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
