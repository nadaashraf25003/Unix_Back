using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unix.Data.Modules.Academic.DTOs;
using Unix.Data.Services.Interfaces.IServices.Academic;

namespace Unix.Controllers
{
    [ApiController]
    [Route("instructor-courses")]
    [Authorize(Roles = "Admin")]
    public class InstructorCoursesController : ControllerBase
    {
        private readonly IInstructorCourseService _service;

        public InstructorCoursesController(IInstructorCourseService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Assign(InstructorCourseDto dto)
        {
            await _service.AssignAsync(dto);
            return Ok();
        }

        [HttpGet("course/{courseId}")]
        public async Task<IActionResult> GetByCourse(int courseId)
            => Ok(await _service.GetByCourseAsync(courseId));
    }

}
