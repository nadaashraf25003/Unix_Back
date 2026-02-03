using Unix.Data.Modules.Dashboard.DTOs;

namespace Unix.Data.Services.Interfaces.IServices.Dashboard
{
    public interface IDashboardService
    {
        Task<StudentDashboardDto> GetStudentDashboardAsync(long userId);
        Task<AdminDashboardDto> GetAdminDashboardAsync();
    }

}
