using Application.Users.ReadModels;
using Mediator;

namespace Application.Users.Queries.GetUsers;

public record GetUsersQuery() : IQuery<List<UserListItemReadModel>>;
