using Unix.Data.Modules.Campus.DTOs;

namespace Unix.Data.Services.Interfaces.IServices.Campus
{
    public interface ICampusService
    {
        // Buildings
        Task<List<BuildingDto>> GetBuildingsAsync();
        Task CreateBuildingAsync(BuildingDto dto);

        // Rooms
        Task<List<RoomDto>> GetRoomsAsync();
        Task<List<RoomDto>> GetRoomsByBuildingAsync(int buildingId);
        Task CreateRoomAsync(RoomDto dto);

        // Tables
        Task<List<TableDto>> GetTablesByRoomAsync(int roomId);
        Task OccupyTableAsync(int tableId);
        Task ReleaseTableAsync(int tableId);

        // Room Availability
        Task<List<RoomAvailabilityDto>> GetRoomAvailabilityAsync();

        // Equipment
        Task<List<EquipmentDto>> GetEquipmentByRoomAsync(int roomId);
        Task AddEquipmentAsync(EquipmentDto dto);

        // Maintenance
        Task<List<MaintenanceRequestDto>> GetMaintenanceRequestsAsync();
        Task CreateMaintenanceRequestAsync(MaintenanceRequestDto dto, long reportedById);
        Task UpdateMaintenanceStatusAsync(long id, string status);
    }

}
