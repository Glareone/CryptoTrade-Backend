

namespace CQRS_using_MediatR.Features.User
{
    using CQRS_using_MediatR.Common.Infrastructure.ResponseTemplate;
    using CQRS_using_MediatR.Features.User.Dtos;
    using MediatR;

    public class GetUserRequestQuery : IRequest<ResponseTemplate<UserDto>>
    {
        public int UserId { get; init; }
    }
}
