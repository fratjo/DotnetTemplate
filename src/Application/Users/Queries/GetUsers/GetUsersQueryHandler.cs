using Application.Users.ReadModels;
using Application.Users.ReadStores;
using Mediator;

namespace Application.Users.Queries.GetUsers;

public sealed class GetUsersQueryHandler(IUserReadStore store) : IQueryHandler<GetUsersQuery, List<UserListItemReadModel>>
{
    public async Task<List<UserListItemReadModel>> HandleAsync(GetUsersQuery query, CancellationToken cancellationToken = default)
    {
        var rows = await store.GetAllAsync(cancellationToken);
        
        return rows.Select(user => new UserListItemReadModel
        {
            Id = user.Id,
            Username = user.Username
        }).ToList();
    }
}
