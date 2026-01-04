using Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Mediator;

public static class MediatorRegistrationExtensions
{
    public static void RegisterCommandFrom<TCommand, TResponse>(this ConcreteMediator mediator, IServiceProvider sp) where TCommand : ICommand<TResponse>
    {
        mediator.Register(sp.GetRequiredService<ICommandHandler<TCommand, TResponse>>());
    }

    public static void RegisterQueryFrom<TQuery, TResponse>(this ConcreteMediator mediator, IServiceProvider sp) where TQuery : IQuery<TResponse>
    {
        mediator.Register(sp.GetRequiredService<IQueryHandler<TQuery, TResponse>>());
    }
}
