using System.Collections.Generic;
using System.Threading.Tasks;
using CQRS_using_MediatR.Features.HistoricalData.Dtos;

namespace CQRS_using_MediatR.Infrastructure.BrokerClients
{
    public interface IBtcBrokerClient
    {
        Task<IList<HistoricalDataDto>> GetDataAsync();
    }
}
