using Microsoft.EntityFrameworkCore;
using Unix.Data.Models.Auth;
using Unix.Data.Services.Interfaces.IRepository.Auth;

namespace Unix.Data.Services.Implementations.Repository.Auth
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) => _context = context;

        public async Task AddAsync(User user)
        {
            await _context.Set<User>().AddAsync(user);

            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Set<User>().ToListAsync();
        }     

     
        public async Task<User?> GetByIdAsync(long id)
        {
            return await _context.Set<User>().FindAsync(id);
        }

        public async Task UpdateAsync(User user)
        {
            _context.Set<User>().Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Set<User>().FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<bool> ExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task DeleteAsync(string email)
        {
            var user = await GetByEmailAsync(email);
            if (user != null)
            {
                _context.Set<User>().Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }

}
