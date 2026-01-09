using Application.Users.ReadModels;
using Application.Users.ReadStores;
using Mediator;
using Shared;

namespace Application.Users.Queries.GetUser;

public sealed class GetUserQueryHandler(IUserReadStore store) : IQueryHandler<GetUserQuery, Maybe<UserReadModel>>
{
    public async Task<Maybe<UserReadModel>> HandleAsync(GetUserQuery query, CancellationToken cancellationToken = default)
    {
        var userReadModel = await store.GetByIdAsync(query.UserId, cancellationToken);

        return userReadModel is null ? Maybe<UserReadModel>.None() : Maybe<UserReadModel>.Some(userReadModel);
    }
}
