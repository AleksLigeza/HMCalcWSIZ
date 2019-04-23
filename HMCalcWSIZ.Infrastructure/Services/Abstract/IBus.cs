using System.Threading;
using MediatR;
using System.Threading.Tasks;

namespace HMCalcWSIZ.Infrastructure.Services.Abstract
{
    public interface IBus
    {
        Task Run<TRequest>(TRequest request, CancellationToken cancellationToken = default) where TRequest : IRequest;

        Task<TResponse> Run<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default) where TRequest : IRequest<TResponse>;
    }
}
