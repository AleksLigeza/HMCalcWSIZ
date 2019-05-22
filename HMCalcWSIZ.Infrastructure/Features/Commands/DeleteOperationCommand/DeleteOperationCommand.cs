using MediatR;

namespace HMCalcWSIZ.Infrastructure.Features.Commands.DeleteOperationCommand
{
    public class DeleteOperationCommand : IRequest
    {
        public int Id { get; set; }

        public string Username { get; set; }
    }
}