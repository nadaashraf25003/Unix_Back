using MediatR;

namespace Unix.Data.Modules.Auth.Commands
{
    public record ApproveUserCommand(long UserId) : IRequest<Unit>;

}
