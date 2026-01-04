using Application.Users.Commands.CreateUser;
using Application.Users.Commands.UpdateUser;
using Application.Users.Queries.GetUser;
using Application.Users.Queries.GetUsers;
using Application.Users.ReadModels;
using Domain.Common;
using Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection;

public static partial class DependencyInjection
{
   public static IServiceCollection AddUserHandlers(this IServiceCollection services)
   {
        services.AddScoped<ICommandHandler<CreateUserCommand, Result<Guid>>, CreateUserCommandHandler>();
        services.AddScoped<ICommandHandler<UpdateUserCommand, Result>, UpdateUserCommandHandler>();

        services.AddScoped<IQueryHandler<GetUserQuery, Option<UserReadModel>>, GetUserQueryHandler>();
        services.AddScoped<IQueryHandler<GetUsersQuery, List<UserListItemReadModel>>, GetUsersQueryHandler>();

        return services;
    }
}
