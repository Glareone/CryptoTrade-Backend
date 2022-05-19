using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS_using_MediatR.Features.HistoricalData.Dtos;

namespace CQRS_using_MediatR.Infrastructure.BrokerClients.BtcBrokerClient
{
    public class BtcBrokerClient: IBtcBrokerClient
    {
        public Task<IList<HistoricalDataDto>?> GetDataAsync()
        {
            var b = Enumerable.Empty<HistoricalDataDto>();

            return Task.FromResult(b as IList<HistoricalDataDto>);
        }
    }
}
