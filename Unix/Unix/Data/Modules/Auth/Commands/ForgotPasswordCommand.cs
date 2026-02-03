using MediatR;

namespace Unix.Data.Modules.Auth.Commands
{
    public record ForgotPasswordCommand(string Email) : IRequest<Unit>;

}
