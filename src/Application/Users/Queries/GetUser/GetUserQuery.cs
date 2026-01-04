using Application.Users.ReadModels;
using Domain.Common;
using Mediator;

namespace Application.Users.Queries.GetUser;

public record GetUserQuery(Guid UserId) : IQuery<Option<UserReadModel>>;
