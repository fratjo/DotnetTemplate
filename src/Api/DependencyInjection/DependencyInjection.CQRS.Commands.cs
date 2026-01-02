using Application.Abstractions.Mediator;
using Application.Users.Commands.CreateUser;
using Application.Users.Commands.UpdateUser;
using Domain.Common;

namespace Api.DependencyInjection;

public static partial class DependencyInjection
{
    public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
    {
        services.AddScoped<ICommandHandler<CreateUserCommand, Result<Guid>>, CreateUserCommandHandler>();
        services.AddScoped<ICommandHandler<UpdateUserCommand, Result>, UpdateUserCommandHandler>();

        return services;
    }
}
