using Application.Users.ReadModels;
using Mediator;
using Shared;

namespace Application.Users.Queries.GetUser;

public record GetUserQuery(Guid UserId) : IQuery<Maybe<UserReadModel>>;
