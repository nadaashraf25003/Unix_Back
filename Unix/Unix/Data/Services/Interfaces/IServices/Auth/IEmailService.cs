namespace Unix.Data.Services.Interfaces.IServices.Auth
{
    public interface IEmailService
    {
        Task SendVerificationEmailAsync(string email, string code);
        Task SendResetPasswordEmailAsync(string email, string code);
    }
}