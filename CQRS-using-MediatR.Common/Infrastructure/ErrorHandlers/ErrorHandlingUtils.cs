using System.Collections.Generic;
using CQRS_using_MediatR.Common.Infrastructure.ResponseTemplate;

namespace CQRS_using_MediatR.Common.Infrastructure.ErrorHandlers
{
    public static class ErrorHandlingUtils
    {
        public static ResponseTemplate<T> GetResponseTemplate<T>(ErrorCode errorCode, string? errorMessage = null, IEnumerable<string>? errorDetails = null)
        {
            return new ResponseTemplate<T>(new ErrorDetails(errorCode, string.IsNullOrEmpty(errorMessage) ? GetErrorMessageDefault(errorCode) : errorMessage, errorDetails));
        }

        private static string GetErrorMessageDefault(ErrorCode errorCode)
        {
            if (UserFriendlyErrorCodeMessage.TryGetValue(errorCode, out var result))
            {
                return result;
            }

            return UserFriendlyErrorCodeMessage[ErrorCode.Unknown];
        }

        private static readonly Dictionary<ErrorCode, string> UserFriendlyErrorCodeMessage = new()
        {
            { ErrorCode.Unknown, "Something went wrong. Please contact Administrator." },
            { ErrorCode.Input, "Your input was wrong. Please check inserted values." },
            { ErrorCode.Permissions, "You are not authorized to perform this action." },
            { ErrorCode.InternalError, "Internal Server Error. Underlined method throws an error" }
        };
    }
}
