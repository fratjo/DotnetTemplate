using Application.Abstractions.Mediator;
using Application.Users.Queries.GetUsers;
using FastEndpoints;

namespace Api.Endpoints.Users;

public class GetUsersResponse
{
    public List<GetUserResponse> users { get; set; } = new();
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
        var command = new GetUsersQuery();
        var user = await mediator.SendAsync(command, ct);
        
        await Send.OkAsync( new GetUsersResponse {
            users = user.Select(u => new GetUserResponse {
                Id = u.Id,
                Username = u.Username
            }).ToList()
        });
    }
}
