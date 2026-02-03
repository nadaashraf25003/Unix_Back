using MediatR;
using Unix.Data.Modules.Auth.Commands;
using Unix.Data.Modules.Auth.DTOs;
using Unix.Data.Services.Interfaces.IRepository.Auth;
using Unix.Data.Services.Interfaces.IServices.Auth;

namespace Unix.Data.Modules.Auth.Handler
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResult>
    {
        private readonly IUserRepository _userRepo;
        private readonly ITokenService _tokenService;

        public LoginCommandHandler(IUserRepository userRepo, ITokenService tokenService)
        {
            _userRepo = userRepo;
            _tokenService = tokenService;
        }

        public async Task<AuthResult> Handle(LoginCommand request, CancellationToken ct)
        {
            // Get user by email
            var user = await _userRepo.GetByEmailAsync(request.Email)
                ?? throw new InvalidOperationException("Invalid credentials");

            if (!user.IsEmailVerified)
                throw new InvalidOperationException("Email not verified");

            if (!user.IsActive)
                throw new InvalidOperationException("Your account is pending admin approval.");

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                throw new InvalidOperationException("Invalid credentials");

            // Generate tokens
            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken(user.Id);

            // Map user info
            var userDto = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
                Stage = user.Stage,
                DepartmentId = user.DepartmentId

            };

            return new AuthResult
            {
                User = userDto,
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token,
                ExpiresIn = 3600
            };
        }
    }
}
