using Microsoft.EntityFrameworkCore;
using Unix.Data.Models.Content;
using Unix.Data.Services.Interfaces.IServices.Content;

namespace Unix.Data.Services.Implementations.Services.Content
{
    public class ContentLostAndFoundService : IContentLostAndFoundService
    {
        private readonly AppDbContext _context;

        public ContentLostAndFoundService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<LostAndFoundDto>> GetAllAsync() =>
            await _context.LostAndFoundItems
                .Select(i => new LostAndFoundDto
                {
                    Id = i.Id,
                    ItemName = i.ItemName,
                    ItemType = i.ItemType,
                    Location = i.Location,
                    Date = i.Date,
                    ContactInfo = i.ContactInfo,
                    IsResolved = i.IsResolved
                }).ToListAsync();

        public async Task CreateAsync(CreateLostAndFoundDto dto, long reportedById)
        {
            _context.LostAndFoundItems.Add(new LostAndFoundItem
            {
                ItemName = dto.ItemName,
                ItemType = dto.ItemType,
                Location = dto.Location,
                Date = dto.Date,
                ContactInfo = dto.ContactInfo,
                ReportedById = reportedById,
                IsResolved = false
            });
            await _context.SaveChangesAsync();
        }

        public async Task ResolveAsync(long id)
        {
            var item = await _context.LostAndFoundItems.FindAsync(id) ?? throw new Exception("Item not found");
            item.IsResolved = true;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var item = await _context.LostAndFoundItems.FindAsync(id) ?? throw new Exception("Item not found");
            _context.LostAndFoundItems.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
