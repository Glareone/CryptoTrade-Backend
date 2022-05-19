using CQRS_using_MediatR.DAL.Entities;
using System.Collections.Generic;

namespace CQRS_using_MediatR.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        public IList<User> Users { get; } = new List<User>
        {
            new() { Id = 1, Name = "Alex", IsDeleted = false},
            new() { Id = 2, Name = "Vaidas", IsDeleted = false },
            new() { Id = 3, Name = "Donatas", IsDeleted = false },
            new() { Id = 4, Name = "Andrew", IsDeleted = false },
            new() { Id = 5, Name = "Aleksandr", IsDeleted = false },
            new() { Id = 6, Name = "Dzmitry", IsDeleted = false },
            new() { Id = 7, Name = "Grzegorz", IsDeleted = false },
        };
    }
}
