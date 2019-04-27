using MediatR;

namespace HMCalcWSIZ.Infrastructure.Features.Commands.UpdateUserCommand
{
    public class UpdateUserCommand : IRequest
    {
        public string Email { get; set; }
    }
}
