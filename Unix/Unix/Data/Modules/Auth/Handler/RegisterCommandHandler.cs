using MediatR;
using Unix.Data.Modules.Auth.Commands;
using Unix.Data.Models.Auth;
using Unix.Data.Services.Interfaces.IRepository.Auth;
using Unix.Data.Services.Interfaces.IServices.Auth;
using Unix.Data.Static;

namespace Unix.Data.Modules.Auth.Handler
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Unit>
    {
        private readonly IUserRepository _userRepo;
        private readonly IEmailVerificationRepository _codeRepo;
        private readonly IEmailService _emailService;

        public RegisterCommandHandler(
            IUserRepository userRepo,
            IEmailVerificationRepository codeRepo,
            IEmailService emailService)
        {
            _userRepo = userRepo;
            _codeRepo = codeRepo;
            _emailService = emailService;
        }

        public async Task<Unit> Handle(RegisterCommand request, CancellationToken ct)
        {
            if (await _userRepo.ExistsAsync(request.Email))
                throw new InvalidOperationException("Email already registered");

            await _codeRepo.InvalidateOldCodesByEmail(request.Email);

            var code = new EmailVerificationCode
            {
                Name = request.Name,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = request.Role,
                Code = new Random().Next(100000, 999999).ToString(),
                ExpiryDate = DateTime.UtcNow.AddMinutes(10),
                IsUsed = false,
                Stage = request.Stage,
                DepartmentId = request.DepartmentId,

            };

            await _codeRepo.AddAsync(code);
            await _emailService.SendVerificationEmailAsync(code.Email, code.Code);

            return Unit.Value;
        }
    }
}
