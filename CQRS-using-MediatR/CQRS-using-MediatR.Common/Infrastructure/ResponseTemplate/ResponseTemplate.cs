using System.Text.Json.Serialization;
using CQRS_using_MediatR.Common.Infrastructure.ErrorHandlers;

namespace CQRS_using_MediatR.Common.Infrastructure.ResponseTemplate
{
    using System;

    [Serializable]
    public class ResponseTemplate<T>
    {
        [JsonConstructor]
        public ResponseTemplate(T content)
        {
            Content = content;
        }

        public ResponseTemplate(ErrorDetails errorDetails)
        {
            ErrorDetails = errorDetails;
        }

        public T? Content { get; init; }

        public ErrorDetails? ErrorDetails { get; init; }
    }
}
