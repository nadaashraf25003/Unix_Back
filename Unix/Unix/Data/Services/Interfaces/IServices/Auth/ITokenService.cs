using Unix.Data.Models.Auth;

namespace Unix.Data.Services.Interfaces.IServices.Auth
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user);
        RefreshToken GenerateRefreshToken(long userId);
    }
}
