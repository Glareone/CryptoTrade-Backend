using System;
using System.Threading.Tasks;
using CQRS_using_MediatR.Features.HistoricalData.Dtos;
using CQRS_using_MediatR.Infrastructure.BrokerClients;
using CQRS_using_MediatR.Infrastructure.Common.Types;

namespace CQRS_using_MediatR.Infrastructure.Services
{
    public class BrokerService: IBrokerService
    {
        private readonly IBtcBrokerClient _btcBrokerClient;
            
        public BrokerService(IBtcBrokerClient btcBrokerClient) => _btcBrokerClient = btcBrokerClient;

        public async Task<HistoricalDataDto> GetHistoricalData(AggregationInterval interval)
        {
            throw new NotImplementedException();
        }
    }
}
