namespace Mediator;

public class ConcreteMediator : IMediator
{
    private readonly Dictionary<Type, Object> _handlers = new Dictionary<Type, object>();


    public void Register<TCommand, TResponse>(ICommandHandler<TCommand, TResponse> handler) where TCommand : ICommand<TResponse>
        => _handlers[typeof(TCommand)] = handler;

    public void Register<TQuery, TResponse>(IQueryHandler<TQuery, TResponse> handler) where TQuery : IQuery<TResponse>
        => _handlers[typeof(TQuery)] = handler;

    public async Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default)
    {
        if (!_handlers.TryGetValue(command.GetType(), out var handler))
            throw new InvalidOperationException($"No handler registered for command of type {command.GetType().Name}");

        return await ((dynamic)handler).HandleAsync((dynamic)command, cancellationToken);
    }

    public async Task<TResponse> AskAsync<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default)
    {
        if (!_handlers.TryGetValue(query.GetType(), out var handler))
            throw new InvalidOperationException($"No handler registered for query of type {query.GetType().Name}");

        return await ((dynamic)handler).HandleAsync((dynamic)query, cancellationToken);
    }
}
