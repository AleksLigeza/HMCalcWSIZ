using System.Threading;
using System.Threading.Tasks;
using HMCalcWSIZ.Infrastructure.Services.Abstract;
using MediatR;

namespace HMCalcWSIZ.Infrastructure.Services.Concrete
{
    public class Bus : IBus
    {
        private readonly IMediator mediator;

        public Bus(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Task Run<TRequest>(TRequest request, CancellationToken cancellationToken = default) where TRequest : IRequest
        {
            return Run<TRequest, Unit>(request, cancellationToken);
        }

        public async Task<TResponse> Run<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default) where TRequest : IRequest<TResponse>
        {
            var response = await mediator.Send(request, cancellationToken);
            return response;
        }
    }
}