using MediatR;

namespace HMCalcWSIZ.Infrastructure.Features.Queries.GetSummaryQuery
{
    public class GetSummaryQuery : IRequest<GetSummaryQueryResult>
    {
        public string Username { get; set; }
    }
}