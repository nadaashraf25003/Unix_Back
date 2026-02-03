using MediatR;
using Unix.Data.Models.Auth;
using Unix.Data.Modules.Auth.Commands;
using Unix.Data.Services.Interfaces.IRepository.Auth;
using Unix.Data.Services.Interfaces.IServices.Auth;

namespace Unix.Data.Modules.Auth.Handler
{
    public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, Unit>
    {
        private readonly IEmailService _emailService;
        private readonly IUserRepository _userRepository;
        private readonly IEmailVerificationRepository _emailVerificationRepository;

        public ForgotPasswordCommandHandler(
            IEmailService emailService,
            IUserRepository userRepository,
            IEmailVerificationRepository emailVerificationRepository)
        {
            _emailService = emailService;
            _userRepository = userRepository;
            _emailVerificationRepository = emailVerificationRepository;
        }

        public async Task<Unit> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null)
                throw new InvalidOperationException("Email not found.");

            var code = new Random().Next(100000, 999999).ToString();

            var verification = new EmailVerificationCode
            {
                Email = user.Email,
                Code = code,
                ExpiryDate = DateTime.UtcNow.AddMinutes(15),
                IsUsed = false,
                Name = user.Name,
                PasswordHash = user.PasswordHash,
                Role = user.Role
            };

            await _emailVerificationRepository.AddAsync(verification);
            await _emailService.SendResetPasswordEmailAsync(user.Email, code);

            return Unit.Value;
        }
    }
}
