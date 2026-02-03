using Microsoft.EntityFrameworkCore;
using Unix.Data.Models.Projects;
using Unix.Data.Modules.Projects.DTOs;
using Unix.Data.Services.Interfaces.IServices.Projects;

namespace Unix.Data.Services.Implementations.Services.Projects
{
    public class ProjectService : IProjectService
    {
        private readonly AppDbContext _context;

        public ProjectService(AppDbContext context)
        {
            _context = context;
        }

        // GET ALL PROJECTS
        public async Task<List<GraduationProjectDto>> GetAllProjectsAsync()
        {
            return await _context.GraduationProjects
                .Select(p => new GraduationProjectDto
                {
                    Id = p.Id,
                    ProjectName = p.ProjectName,
                    MemberCount = p.Members.Count
                })
                .ToListAsync();
        }

        // GET MY PROJECTS
        public async Task<List<GraduationProjectDto>> GetMyProjectsAsync(long studentId)
        {
            return await _context.ProjectMembers
                .Where(pm => pm.StudentId == studentId)
                .Select(pm => new GraduationProjectDto
                {
                    Id = pm.Project.Id,
                    ProjectName = pm.Project.ProjectName,
                    MemberCount = pm.Project.Members.Count
                })
                .ToListAsync();
        }

        // CREATE PROJECT
        public async Task CreateProjectAsync(CreateProjectDto dto)
        {
            _context.GraduationProjects.Add(new GraduationProject
            {
                ProjectName = dto.ProjectName,
                CreatedAt = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();
        }

        // JOIN PROJECT
        public async Task JoinProjectAsync(long projectId, long studentId)
        {
            var exists = await _context.ProjectMembers
                .AnyAsync(pm => pm.ProjectId == projectId && pm.StudentId == studentId);

            if (exists)
                throw new Exception("Already joined this project");

            _context.ProjectMembers.Add(new ProjectMember
            {
                ProjectId = projectId,
                StudentId = studentId,
                CreatedAt = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();
        }

        // GET PROJECT MEMBERS
        public async Task<List<ProjectMemberDto>> GetProjectMembersAsync(long projectId)
        {
            return await _context.ProjectMembers
                .Where(pm => pm.ProjectId == projectId)
                .Select(pm => new ProjectMemberDto
                {
                    StudentId = pm.StudentId,
                    StudentName = pm.Student.User.Name
                })
                .ToListAsync();
        }
    }

}
