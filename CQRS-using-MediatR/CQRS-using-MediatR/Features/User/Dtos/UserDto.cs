namespace CQRS_using_MediatR.Features.User.Dtos
{
    public class UserDto
    {
        public int Id { get; init; }

        public string? Name { get; init; }

        public bool IsDeleted { get; init; }
    }
}
