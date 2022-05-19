using System;

namespace CQRS_using_MediatR.Common.Infrastructure.BrokerClients
{
    public class HistoricalData
    {
        public Int64 Timestamp { get; init; }

        public double Open { get; init; }

        public double High { get; init; }

        public double Low { get; init; }

        public double Close { get; init; }

        public double VolumeBTC { get; init; }

        public double VolumeCur { get; init; }

        public double WeightedPrice { get; init; }
    }
}
