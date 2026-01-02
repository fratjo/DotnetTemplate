using Application.Abstractions.Mediator;
using Infrastructure.Mediator;

namespace Api.DependencyInjection;

public static partial class DependencyInjection
{   
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddScoped<IMediator, Mediator>();

        return services;
    }

}
