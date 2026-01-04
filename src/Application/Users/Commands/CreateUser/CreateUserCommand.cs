using Domain.Common;
using Mediator;

namespace Application.Users.Commands.CreateUser;

public record CreateUserCommand(string Username, int Age) : ICommand<Result<Guid>>;