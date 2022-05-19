using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRS_using_MediatR.Common.Infrastructure.BrokerClients
{
    public interface IBtcBrokerClient
    {
        Task<IList<HistoricalData>> GetDataAsync();
    }
}
