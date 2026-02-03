using Unix.Data.Models.Auth;

namespace Unix.Data.Services.Interfaces.IRepository.Auth
{
    public interface IEmailVerificationRepository
    {
        Task AddAsync(EmailVerificationCode code);
        Task<EmailVerificationCode?> GetValidCodeAsync(string email, string code);
        Task InvalidateOldCodes(long userId);
        Task InvalidateOldCodesByEmail(string email);
        Task UpdateAsync(EmailVerificationCode code);
        Task<EmailVerificationCode?> GetLatestByEmailAsync(string email);
    }
}
