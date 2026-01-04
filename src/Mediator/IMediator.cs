namespace Mediator;

public interface IMediator
{
    void Register<TCommand, TResponse>(ICommandHandler<TCommand, TResponse> handler) where TCommand : ICommand<TResponse>;

    void Register<TQuery, TResponse>(IQueryHandler<TQuery, TResponse> handler) where TQuery : IQuery<TResponse>;

    Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default);
    
    Task<TResponse> AskAsync<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default);
}

