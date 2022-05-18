using System.Collections.Generic;

namespace CQRS_using_MediatR.Common.Infrastructure.ErrorHandlers
{
    public class ErrorDetails
    {
        public ErrorDetails() { }

        public ErrorDetails(ErrorCode errorGroupCode, string message, IEnumerable<string> details = null)
        {
            ErrorCode = (int) errorGroupCode;
            Message = message;
            Details = details;
        }

        public int ErrorCode { get; init; }

        public string Message { get; init; }

        public IEnumerable<string>? Details { get; init; }
    }
}
