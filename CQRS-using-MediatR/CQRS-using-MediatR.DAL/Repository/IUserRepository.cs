using System.Collections.Generic;
using CQRS_using_MediatR.DAL.Entities;

namespace CQRS_using_MediatR.DAL.Repository
{
    public interface IUserRepository
    {
        public IList<User> Users { get; }
    }
}
