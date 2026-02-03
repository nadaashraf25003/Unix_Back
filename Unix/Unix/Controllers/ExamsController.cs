using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unix.Data.Modules.Academic.DTOs;
using Unix.Data.Services.Interfaces.IServices.Academic;

namespace Unix.Controllers
{
    [ApiController]
    [Route("exams")]
    public class ExamsController : ControllerBase
    {
        private readonly IExamService _service;

        public ExamsController(IExamService service)
        {
            _service = service;
        }

        // STUDENT VIEW
        [HttpGet("student")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetStudentExams()
        {
            var userId = long.Parse(User.FindFirst("id")!.Value);
            return Ok(await _service.GetStudentExamsAsync(userId));
        }

        // ADMIN ACTIONS
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateExamDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(long id, CreateExamDto dto)
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
