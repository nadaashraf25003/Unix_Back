using Unix.Data.Modules.Campus.DTOs;

namespace Unix.Data.Services.Interfaces.IServices.Campus
{
    public interface ICampusNavigationService
    {
        Task<List<RoomPathDto>> GetAllPathsAsync();
        Task<RoomPathDto?> GetPathAsync(int fromRoomId, int toRoomId);
    }

}
