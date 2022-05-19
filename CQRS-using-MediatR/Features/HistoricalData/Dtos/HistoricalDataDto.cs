using System;

namespace CQRS_using_MediatR.Features.HistoricalData.Dtos
{
    public class HistoricalDataDto
    {
        public double DailyLow { get; init; }

        public double DailyHigh { get; init; }

        public double Open { get; init; }

        public double Close { get; init; }
    }
}
