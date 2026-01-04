using Domain.Common;
using Mediator;

namespace Application.Users.Commands.UpdateUser;

public record UpdateUserCommand(Guid UserId, string? Username, int? Age) : ICommand<Result>;
