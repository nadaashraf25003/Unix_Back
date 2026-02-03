using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unix.Data.Modules.Academic.DTOs;
using Unix.Data.Services.Interfaces.IServices.Academic;

namespace Unix.Controllers
{
    [ApiController]
    [Route("course-assignments")]
    [Authorize(Roles = "Admin")]
    public class CourseAssignmentsController : ControllerBase
    {
        private readonly ICourseAssignmentService _service;

        public CourseAssignmentsController(ICourseAssignmentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Assign(CourseAssignmentDto dto)
        {
            await _service.AssignAsync(dto);
            return Ok();
        }

        [HttpGet("section/{sectionId}")]
        public async Task<IActionResult> GetBySection(int sectionId)
            => Ok(await _service.GetBySectionAsync(sectionId));
    }

}
