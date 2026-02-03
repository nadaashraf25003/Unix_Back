using MediatR;
using Unix.Data.Modules.Auth.DTOs;
using Unix.Data.Services.Interfaces.IRepository.Auth;
using Unix.Data.Services.Interfaces.IServices.Auth;

namespace Unix.Data.Modules.Auth.Commands
{
    public record RefreshTokenCommand(string RefreshToken) : IRequest<AuthResult>;

    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, AuthResult>
    {
        private readonly IRefreshTokenRepository _repo;
        private readonly ITokenService _tokenService;

        public RefreshTokenCommandHandler(IRefreshTokenRepository repo, ITokenService tokenService)
        {
            _repo = repo;
            _tokenService = tokenService;
        }

        public async Task<AuthResult> Handle(RefreshTokenCommand request, CancellationToken ct)
        {
            var token = await _repo.GetValidAsync(request.RefreshToken)
                ?? throw new InvalidOperationException("Invalid refresh token");

            var user = token.User;

            return new AuthResult
            {
                AccessToken = _tokenService.GenerateAccessToken(user),
                RefreshToken = token.Token
            };
        }
    }
}
