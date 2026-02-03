using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unix.Data.Modules.Projects.DTOs;
using Unix.Data.Services.Interfaces.IServices.Projects;

namespace Unix.Controllers
{
    [ApiController]
    [Route("projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _service;

        public ProjectsController(IProjectService service)
        {
            _service = service;
        }

        // GET ALL PROJECTS
        [HttpGet]
        [Authorize(Roles = "Student,Admin")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllProjectsAsync());
        }

        // CREATE PROJECT
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateProjectDto dto)
        {
            await _service.CreateProjectAsync(dto);
            return Ok();
        }

        // JOIN PROJECT
        [HttpPost("{projectId}/join")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> Join(long projectId)
        {
            var studentId = long.Parse(User.FindFirst("id")!.Value);
            await _service.JoinProjectAsync(projectId, studentId);
            return Ok();
        }

        // GET MY PROJECTS
        [HttpGet("my")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetMyProjects()
        {
            var studentId = long.Parse(User.FindFirst("id")!.Value);
            return Ok(await _service.GetMyProjectsAsync(studentId));
        }

        // GET PROJECT MEMBERS
        [HttpGet("{projectId}/members")]
        [Authorize(Roles = "Student,Admin")]
        public async Task<IActionResult> GetMembers(long projectId)
        {
            return Ok(await _service.GetProjectMembersAsync(projectId));
        }
    }

}
