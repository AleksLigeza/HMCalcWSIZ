using HMCalcWSIZ.Core.DTO;
using MediatR;

namespace HMCalcWSIZ.Infrastructure.Features.Queries.GetOperationQuery
{
    public class GetOperationQuery : IRequest<OperationDTO>
    {
        public int Id { get; set; }

        public string Username { get; set; }
    }
}