using Application.Common.Mediator;
using Application.DTOs.UserDto;
using Domain.Repositories;

namespace Application.Queries.Users.GetUser;

public class GetUserQueryHandler(IUserRepository userRepository) : IQueryHandler<GetUserQuery, UserDto?>
{
    public async Task<UserDto?> HandleAsync(GetUserQuery query, CancellationToken? cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(query.UserId, cancellationToken);
        return user?.ToUserDto();
    }
}
