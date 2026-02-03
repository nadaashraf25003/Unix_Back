using Microsoft.EntityFrameworkCore;
using Unix.Data.Modules.Campus.DTOs;
using Unix.Data.Services.Interfaces.IServices.Campus;

namespace Unix.Data.Services.Implementations.Services.Campus
{
    public class CampusNavigationService : ICampusNavigationService
    {
        private readonly AppDbContext _context;

        public CampusNavigationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<RoomPathDto>> GetAllPathsAsync() =>
            await _context.RoomPaths
                .Select(rp => new RoomPathDto
                {
                    Id = rp.Id,
                    FromRoomId = rp.FromRoomId,
                    ToRoomId = rp.ToRoomId,
                    PathDescription = rp.PathDescription
                }).ToListAsync();

        public async Task<RoomPathDto?> GetPathAsync(int fromRoomId, int toRoomId) =>
            await _context.RoomPaths
                .Where(rp => rp.FromRoomId == fromRoomId && rp.ToRoomId == toRoomId)
                .Select(rp => new RoomPathDto
                {
                    Id = rp.Id,
                    FromRoomId = rp.FromRoomId,
                    ToRoomId = rp.ToRoomId,
                    PathDescription = rp.PathDescription
                }).FirstOrDefaultAsync();
    }

}
