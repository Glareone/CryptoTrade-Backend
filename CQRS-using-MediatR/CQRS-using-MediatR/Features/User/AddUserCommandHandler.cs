using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CQRS_using_MediatR.Common.Infrastructure.ResponseTemplate;
using CQRS_using_MediatR.DAL.Repository;
using CQRS_using_MediatR.Features.User.Dtos;
using MediatR;

namespace CQRS_using_MediatR.Features.User
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, ResponseTemplate<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AddUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ResponseTemplate<UserDto>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var lenght = _userRepository.Users.Count();

            var newUser = new UserDto
            {
                Id = lenght + 1,
                Name = request.Name,
                IsDeleted = request.IsDeleted,
            };

            _userRepository.Users.Add(_mapper.Map<DAL.Entities.User>(newUser));

            return new ResponseTemplate<UserDto>(newUser);
        }
    }
}
