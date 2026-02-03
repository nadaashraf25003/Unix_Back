using Unix.Data.Modules.Projects.DTOs;

namespace Unix.Data.Services.Interfaces.IServices.Projects
{
    public interface IProjectService
    {
        Task<List<GraduationProjectDto>> GetAllProjectsAsync();
        Task<List<GraduationProjectDto>> GetMyProjectsAsync(long studentId);

        Task CreateProjectAsync(CreateProjectDto dto);
        Task JoinProjectAsync(long projectId, long studentId);

        Task<List<ProjectMemberDto>> GetProjectMembersAsync(long projectId);
    }

}
