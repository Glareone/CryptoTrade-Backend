using AutoMapper;
using CQRS_using_MediatR.Features.User.Dtos;

namespace CQRS_using_MediatR.Common.Infrastructure.Mapper
{
    class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DAL.Entities.User, UserDto>().ReverseMap();
        }
    }
}
