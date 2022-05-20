using System.Threading.Tasks;
using CQRS_using_MediatR.Features.HistoricalData.Dtos;
using CQRS_using_MediatR.Infrastructure.Common.Types;

namespace CQRS_using_MediatR.Infrastructure.Services
{
    public interface IBrokerService
    {
        public Task<HistoricalDataDto> GetHistoricalData(AggregationInterval interval);
    }
}
