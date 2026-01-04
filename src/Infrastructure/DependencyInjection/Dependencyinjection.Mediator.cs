using Infrastructure.Mediator;
using Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection;

public static partial class DependencyInjection
{   
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddScoped<IMediator>(sp =>
        {
            var mediator = new ConcreteMediator();

            mediator.RegisterUserModule(sp);

            return mediator;
        });

        return services;
    }
}
