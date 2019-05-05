using MediatR;

namespace HMCalcWSIZ.Infrastructure.Features.Commands.UpdateUserCommand
{
    public class UpdateUserCommand : IRequest
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CurrentPassword { get; set; }
    }
}
