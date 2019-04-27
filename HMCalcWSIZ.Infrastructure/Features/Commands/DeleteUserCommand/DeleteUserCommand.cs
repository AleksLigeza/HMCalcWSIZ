using MediatR;

namespace HMCalcWSIZ.Infrastructure.Features.Commands.DeleteUserCommand
{
    public class DeleteUserCommand: IRequest
    {
        public string Id { get; set; }
    }
}
