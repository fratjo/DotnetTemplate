using Application.Users.ReadStores;
using Domain.Abstractions;
using Domain.Users.Repositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection;

public static partial class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        // Register your repositories here
        services
            .AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped<IUserWriteRepository, UserWriteRepository>();

        // Register Read Stores
        services
            .AddScoped<IUserReadStore, UserReadStore>();

        return services;
    }
}
