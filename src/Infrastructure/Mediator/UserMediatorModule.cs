using Application.Users.Commands.CreateUser;
using Application.Users.Commands.UpdateUser;
using Application.Users.Queries.GetUser;
using Application.Users.Queries.GetUsers;
using Application.Users.ReadModels;
using Mediator;
using Shared;

namespace Infrastructure.Mediator;

public static partial class MediatorModules

{
    public static void RegisterUserModule(this ConcreteMediator mediator, IServiceProvider sp)
    {
        mediator.RegisterCommandFrom<CreateUserCommand, Result<Guid>>(sp);
        mediator.RegisterCommandFrom<UpdateUserCommand, Result>(sp);

        mediator.RegisterQueryFrom<GetUserQuery, Maybe<UserReadModel>>(sp);
        mediator.RegisterQueryFrom<GetUsersQuery, IReadOnlyList<UserListItemReadModel>>(sp);
    }
}
