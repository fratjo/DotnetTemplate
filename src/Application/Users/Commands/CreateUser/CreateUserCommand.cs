using Mediator;
using Shared;

namespace Application.Users.Commands.CreateUser;

public record CreateUserCommand(string Username, int Age) : ICommand<Result<Guid>>;