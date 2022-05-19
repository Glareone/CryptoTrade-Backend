using CQRS_using_MediatR.Common.Infrastructure.ResponseTemplate;
using CQRS_using_MediatR.Features.HistoricalData.Dtos;
using CQRS_using_MediatR.Infrastructure.Common.Types;
using MediatR;

namespace CQRS_using_MediatR.Features.HistoricalData
{
    public class GetHistoricalDataRequestQuery : IRequest<ResponseTemplate<HistoricalDataDto>>
    {
        public AggregationInterval AggregationInterval { get; init; }
    }
}
