using System;
using System.Linq;
using System.Threading.Tasks;
using CQRS_using_MediatR.Common.Infrastructure.BrokerClients;
using CQRS_using_MediatR.Features.HistoricalData.Dtos;
using CQRS_using_MediatR.Infrastructure.Common.Types;

namespace CQRS_using_MediatR.Infrastructure.Services
{
    public class BrokerService: IBrokerService
    {
        private readonly IBtcBrokerClient _btcBrokerClient;
            
        public BrokerService(IBtcBrokerClient btcBrokerClient) => _btcBrokerClient = btcBrokerClient;

        public async Task<HistoricalDataDto> GetHistoricalData(AggregationInterval interval)
        {
            var serverResponse = (await _btcBrokerClient.GetDataAsync()).ToList();

            var interestedServerResponseInterval = interval switch
            {
                AggregationInterval.FifteenMinutes => 15,
                AggregationInterval.OneHour => 60,
                AggregationInterval.OneDay => 1440,
                _ => throw new ArgumentOutOfRangeException(nameof(interval), interval, null)
            };

            interestedServerResponseInterval = interestedServerResponseInterval > serverResponse.Count
                ? serverResponse.Count
                : interestedServerResponseInterval;

            var serverResponseWithInterval =
                serverResponse.GetRange(serverResponse.Count - interestedServerResponseInterval,
                    interestedServerResponseInterval);

            var dayFirstData = serverResponse.Aggregate((curMin, x) => (x.Timestamp < curMin.Timestamp ? x : curMin));
            var dayLastData = serverResponse.Aggregate((curMax, x) => (x.Timestamp > curMax.Timestamp ? x : curMax));
            var intervalHigh = serverResponseWithInterval.Aggregate((curMax, x) => (x.High > curMax.High ? x : curMax));
            var intervalLow = serverResponseWithInterval.Aggregate((curMin, x) => (x.Low < curMin.Low ? x : curMin));

            var result = new HistoricalDataDto
            {
                Open = dayFirstData.Open,
                Close = dayLastData.Close,
                DailyHigh = intervalHigh.High,
                DailyLow = intervalLow.Low
            };

            return result;
        }
    }
}
