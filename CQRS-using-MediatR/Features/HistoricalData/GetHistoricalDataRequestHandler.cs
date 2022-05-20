using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CQRS_using_MediatR.Common.Infrastructure.ErrorHandlers;
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
            try
            {
                var historicalData = await _brokerService.GetHistoricalData(request.AggregationInterval);
                _logger.LogInformation("[GetHistoricalDataRequestHandler] Handler executed successfully");

                return new ResponseTemplate<HistoricalDataDto>(historicalData);
            }
            catch (Exception e)
            {
                _logger.LogError("[GetHistoricalDataRequestHandler] Handler failed. underlined Service [IBrokerService] throws an error");
                return ErrorHandlingUtils.GetResponseTemplate<HistoricalDataDto>(ErrorCode.InternalError, errorDetails: new List<string>{ e.Message });
            }

        }
    }
}
