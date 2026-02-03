using Azure.Core;
using MediatR;
using Unix.Data.Models.Auth;
using Unix.Data.Services.Interfaces.IRepository.Auth;
using Unix.Data.Services.Interfaces.IServices.Auth;

namespace Unix.Data.Modules.Auth.Commands
{
    // Command that does not return anything
    public record ResendVerificationCommand(string Email) : IRequest<Unit>;

    // Handler with Unit as response type
    public class ResendVerificationCommandHandler : IRequestHandler<ResendVerificationCommand, Unit>
    {
        private readonly IUserRepository _userRepo;
        private readonly IEmailVerificationRepository _codeRepo;
        private readonly IEmailService _emailService;

        public ResendVerificationCommandHandler(
            IUserRepository userRepo,
            IEmailVerificationRepository codeRepo,
            IEmailService emailService)
        {
            _userRepo = userRepo;
            _codeRepo = codeRepo;
            _emailService = emailService;
        }

        public async Task<Unit> Handle(ResendVerificationCommand request, CancellationToken ct)
        {
            var temp = await _codeRepo.GetLatestByEmailAsync(request.Email)
                ?? throw new InvalidOperationException("No pending verification found");

            // Invalidate old codes
            await _codeRepo.InvalidateOldCodesByEmail(request.Email);

            // Create new code
            var newCode = new EmailVerificationCode
            {
                Name = temp.Name,
                Email = temp.Email,
                PasswordHash = temp.PasswordHash,
                Role = temp.Role,
                Code = new Random().Next(100000, 999999).ToString(),
                ExpiryDate = DateTime.UtcNow.AddMinutes(10),
                IsUsed = false
            };

            await _codeRepo.AddAsync(newCode);
            await _emailService.SendVerificationEmailAsync(newCode.Email, newCode.Code);

            return Unit.Value; // ✅ Must return Unit.Value for commands that don't return anything
        }
    }
}
