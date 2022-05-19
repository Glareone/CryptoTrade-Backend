using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CQRS_using_MediatR.Common.Infrastructure.ResponseTemplate;
using CQRS_using_MediatR.Features.HistoricalData.Dtos;
using CQRS_using_MediatR.Infrastructure.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CQRS_using_MediatR.Features.HistoricalData
{
    public class GetHistoricalDataRequestHandler : IRequestHandler<GetHistoricalDataRequestQuery, ResponseTemplate<HistoricalDataDto>>
    {
        private readonly IBrokerService _brokerService;
        private readonly ILogger<GetHistoricalDataRequestHandler> _logger;

        public GetHistoricalDataRequestHandler(IBrokerService brokerService, ILogger<GetHistoricalDataRequestHandler> logger)
        {
            _brokerService = brokerService;
            _logger = logger;
        }

        public async Task<ResponseTemplate<HistoricalDataDto>> Handle(GetHistoricalDataRequestQuery request, CancellationToken cancellationToken)
        {
            var historicalData = await _brokerService.GetHistoricalData(request.AggregationInterval);
            _logger.LogInformation("BTC Broker Data gathered successfully");

            return new ResponseTemplate<HistoricalDataDto>(historicalData);
        }
    }
}
