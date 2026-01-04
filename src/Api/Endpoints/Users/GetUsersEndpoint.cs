using Mediator;
using Application.Users.Queries.GetUsers;
using FastEndpoints;

namespace Api.Endpoints.Users;

public record GetUserListItemResponse
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
}

public class GetUsersResponse
{
    public List<GetUserListItemResponse> users { get; set; } = new();
}

public class GetUsersEndpoint(IMediator mediator) : EndpointWithoutRequest<GetUsersResponse>
{
    public override void Configure()
    {
        Get("api/users");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var query = new GetUsersQuery();
        var user = await mediator.AskAsync(query, ct);
        
        await Send.OkAsync( new GetUsersResponse {
            users = user.Select(u => new GetUserListItemResponse
            {
                Id = u.Id,
                Username = u.Username
            }).ToList()
        });
    }
}
