using Application.Abstractions.Mediator;
using Domain.Common;
using Application.Users.Queries.GetUser;
using Application.Users.Queries.GetUsers;
using Application.Users.ReadModels;

namespace Api.DependencyInjection;

public static partial class DependencyInjection
{
    public static IServiceCollection AddQueryHandlers(this IServiceCollection services)
    {
        services.AddScoped<IQueryHandler<GetUserQuery, Option<UserReadModel>>, GetUserQueryHandler>();
        services.AddScoped<IQueryHandler<GetUsersQuery, List<UserListItemReadModel>>, GetUsersQueryHandler>();

        return services;
    }
}
