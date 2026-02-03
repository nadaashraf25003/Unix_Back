using MediatR;

namespace Unix.Data.Modules.Auth.Commands
{
    public class ResetPasswordCommand : IRequest<Unit>
    {
        public string? Email { get; set; }
        public string? Code { get; set; }
        public string? NewPassword { get; set; }
    }
}
