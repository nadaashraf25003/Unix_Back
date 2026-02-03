using Microsoft.EntityFrameworkCore;
using Unix.Data.Models.Auth;
using Unix.Data.Services.Interfaces.IRepository.Auth;

namespace Unix.Data.Services.Implementations.Repository.Auth
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly AppDbContext _context;
        public RefreshTokenRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(RefreshToken token)
        {
            await _context.RefreshTokens.AddAsync(token);
            await _context.SaveChangesAsync();
        }

        public async Task<RefreshToken?> GetValidAsync(string token)
        {
            return await _context.RefreshTokens
                .Include(t => t.User)
                .FirstOrDefaultAsync(t => t.Token == token && t.ExpiresAt > DateTime.UtcNow && !t.IsRevoked);
        }

        public async Task RevokeAsync(string token)
        {
            var existing = await _context.RefreshTokens.FirstOrDefaultAsync(t => t.Token == token);
            if (existing != null)
            {
                existing.IsRevoked = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
