using Azure.Core;
using MediatR;
using Unix.Data.Static;

namespace Unix.Data.Modules.Auth.Commands
{
    public record RegisterCommand(
     string Name,
     string Email,
     string Password,
     int DepartmentId,
     int Stage,
     UserRole? Role
 ) : IRequest<Unit>;
}
