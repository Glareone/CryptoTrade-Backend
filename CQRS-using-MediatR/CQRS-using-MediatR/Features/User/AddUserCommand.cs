using CQRS_using_MediatR.Common.Infrastructure.ResponseTemplate;
using CQRS_using_MediatR.Features.User.Dtos;
using MediatR;

namespace CQRS_using_MediatR.Features.User
{
    public class AddUserCommand: IRequest<ResponseTemplate<UserDto>>
    {
        public AddUserCommand(string name, bool isDeleted)
        {
            Name = name;
            IsDeleted = isDeleted;
        }

        public string Name { get; init; }

        public bool IsDeleted { get; init; }
    }
}
