using MediatR;
using Unix.Data.Modules.Auth.DTOs;

namespace Unix.Data.Modules.Auth.Commands
{
    public record LoginCommand(string Email, string Password) : IRequest<AuthResult>;

}
