using Microsoft.EntityFrameworkCore;
using Unix.Data.Models.Auth;
using Unix.Data.Services.Interfaces.IRepository.Auth;

namespace Unix.Data.Services.Implementations.Repository.Auth
{
    public class EmailVerificationRepository : IEmailVerificationRepository
    {
        private readonly AppDbContext _context;

        public EmailVerificationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(EmailVerificationCode code)
        {
            await _context.EmailVerificationCodes.AddAsync(code);
            await _context.SaveChangesAsync();
        }

        public async Task<EmailVerificationCode?> GetValidCodeAsync(string email, string code)
        {
            return await _context.EmailVerificationCodes
                .FirstOrDefaultAsync(x =>
                    x.Email == email &&
                    x.Code == code &&
                    !x.IsUsed &&
                    x.ExpiryDate > DateTime.UtcNow);
        }

        public Task InvalidateOldCodes(long userId)
        {
            throw new NotImplementedException();
        }

        public async Task InvalidateOldCodesByEmail(string email)
        {
            var codes = await _context.EmailVerificationCodes
                .Where(c => c.Email == email && !c.IsUsed)
                .ToListAsync();

            codes.ForEach(c => c.IsUsed = true);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EmailVerificationCode code)
        {
            _context.EmailVerificationCodes.Update(code);
            await _context.SaveChangesAsync();
        }

        public async Task<EmailVerificationCode?> GetLatestByEmailAsync(string email)
        {
            return await _context.EmailVerificationCodes
                .Where(c => c.Email == email && !c.IsUsed)
                .OrderByDescending(c => c.Id)
                .FirstOrDefaultAsync();
        }
    }

}
