using Unix.Data.Modules.Auth.DTOs;

namespace Unix.Data.Services.Interfaces.IServices.Auth
{
    public interface IAuthService
    {
        Task<AuthResult> LoginAsync(string email, string password);
        Task<AuthResult> RefreshTokenAsync(string refreshToken);
    }
}
