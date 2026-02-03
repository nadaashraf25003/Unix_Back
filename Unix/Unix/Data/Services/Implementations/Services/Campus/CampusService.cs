using Microsoft.EntityFrameworkCore;
using Unix.Data.Models.Campus;
using Unix.Data.Modules.Campus.DTOs;
using Unix.Data.Services.Interfaces.IServices.Campus;

namespace Unix.Data.Services.Implementations.Services.Campus
{
    public class CampusService : ICampusService
    {
        private readonly AppDbContext _context;

        public CampusService(AppDbContext context)
        {
            _context = context;
        }

        // Buildings
        public async Task<List<BuildingDto>> GetBuildingsAsync() =>
            await _context.Buildings
                .Select(b => new BuildingDto { Id = b.Id, Name = b.Name, Description = b.Description })
                .ToListAsync();

        public async Task CreateBuildingAsync(BuildingDto dto)
        {
            _context.Buildings.Add(new Building { Name = dto.Name, Description = dto.Description });
            await _context.SaveChangesAsync();
        }

        // Rooms
        public async Task<List<RoomDto>> GetRoomsAsync() =>
            await _context.Rooms
                .Select(r => new RoomDto
                {
                    Id = r.Id,
                    RoomCode = r.RoomCode,
                    RoomType = r.RoomType,
                    Capacity = r.Capacity,
                    BuildingId = r.BuildingId,
                    FloorId = r.FloorId
                }).ToListAsync();

        public async Task<List<RoomDto>> GetRoomsByBuildingAsync(int buildingId) =>
            await _context.Rooms
                .Where(r => r.BuildingId == buildingId)
                .Select(r => new RoomDto
                {
                    Id = r.Id,
                    RoomCode = r.RoomCode,
                    RoomType = r.RoomType,
                    Capacity = r.Capacity,
                    BuildingId = r.BuildingId,
                    FloorId = r.FloorId
                }).ToListAsync();

        public async Task CreateRoomAsync(RoomDto dto)
        {
            _context.Rooms.Add(new Room
            {
                RoomCode = dto.RoomCode,
                RoomType = dto.RoomType,
                Capacity = dto.Capacity,
                BuildingId = dto.BuildingId,
                FloorId = dto.FloorId
            });
            await _context.SaveChangesAsync();
        }

        // Tables
        public async Task<List<TableDto>> GetTablesByRoomAsync(int roomId) =>
            await _context.Tables
                .Where(t => t.RoomId == roomId)
                .Select(t => new TableDto { Id = t.Id, TableNumber = t.TableNumber, IsOccupied = t.IsOccupied })
                .ToListAsync();

        public async Task OccupyTableAsync(int tableId)
        {
            var table = await _context.Tables.FindAsync(tableId) ?? throw new Exception("Table not found");
            table.IsOccupied = true;
            table.LastUpdated = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }

        public async Task ReleaseTableAsync(int tableId)
        {
            var table = await _context.Tables.FindAsync(tableId) ?? throw new Exception("Table not found");
            table.IsOccupied = false;
            table.LastUpdated = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }

        // Room Availability
        public async Task<List<RoomAvailabilityDto>> GetRoomAvailabilityAsync() =>
            await _context.RoomAvailabilities
                .Select(r => new RoomAvailabilityDto
                {
                    RoomId = r.RoomId,
                    DayOfWeek = r.DayOfWeek,
                    StartTime = r.StartTime,
                    EndTime = r.EndTime,
                    IsAvailable = r.IsAvailable
                }).ToListAsync();

        // Equipment
        public async Task<List<EquipmentDto>> GetEquipmentByRoomAsync(int roomId) =>
            await _context.Equipment
                .Where(e => e.RoomId == roomId)
                .Select(e => new EquipmentDto { Id = e.Id, Name = e.Name, Quantity = e.Quantity, RoomId = e.RoomId })
                .ToListAsync();

        public async Task AddEquipmentAsync(EquipmentDto dto)
        {
            _context.Equipment.Add(new Equipment { Name = dto.Name, Quantity = dto.Quantity, RoomId = dto.RoomId });
            await _context.SaveChangesAsync();
        }

        // Maintenance
        public async Task<List<MaintenanceRequestDto>> GetMaintenanceRequestsAsync() =>
            await _context.MaintenanceRequests
                .Select(m => new MaintenanceRequestDto { RoomId = m.RoomId, Issue = m.Issue, Status = m.Status })
                .ToListAsync();

        public async Task CreateMaintenanceRequestAsync(MaintenanceRequestDto dto, long reportedById)
        {
            _context.MaintenanceRequests.Add(new MaintenanceRequest
            {
                RoomId = dto.RoomId,
                Issue = dto.Issue,
                Status = "Pending",
                ReportedById = reportedById,
                CreatedAt = DateTime.UtcNow
            });
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMaintenanceStatusAsync(long id, string status)
        {
            var request = await _context.MaintenanceRequests.FindAsync(id) ?? throw new Exception("Request not found");
            request.Status = status;
            await _context.SaveChangesAsync();
        }
    }

}
