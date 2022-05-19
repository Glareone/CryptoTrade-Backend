using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CQRS_using_MediatR.Common.Infrastructure.ResponseTemplate;
using CQRS_using_MediatR.Features.HistoricalData.Dtos;
using CQRS_using_MediatR.Infrastructure.Services;
using MediatR;

namespace CQRS_using_MediatR.Features.HistoricalData
{
    public class GetHistoricalDataRequestHandler : IRequestHandler<GetHistoricalDataRequestQuery, ResponseTemplate<HistoricalDataDto>>
    {
        private IBrokerService _brokerService;
        private IMapper _mapper;

        public GetHistoricalDataRequestHandler(IBrokerService brokerService, IMapper mapper)
        {
            _brokerService = brokerService;
            _mapper = mapper;
        }

        public Task<ResponseTemplate<HistoricalDataDto>> Handle(GetHistoricalDataRequestQuery request, CancellationToken cancellationToken)
        {
            var historicalData = _brokerService.GetHistoricalData(request.AggregationInterval);
            throw new NotImplementedException();
        }
    }
}
