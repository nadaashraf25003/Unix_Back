using Azure.Core;
using MediatR;

namespace Unix.Data.Modules.Auth.Commands
{
    public record VerifyEmailCommand(string Email, string Code) : IRequest<Unit>;

}
