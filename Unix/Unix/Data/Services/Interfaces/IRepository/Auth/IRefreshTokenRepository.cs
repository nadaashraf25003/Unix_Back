using Unix.Data.Models.Auth;

namespace Unix.Data.Services.Interfaces.IRepository.Auth
{
    public interface IRefreshTokenRepository
    {
        Task AddAsync(RefreshToken token);
        Task<RefreshToken?> GetValidAsync(string token); // Gets token if not expired and not revoked
        Task RevokeAsync(string token); // Optional: revoke a token
    }
}
