using Domain.Abstractions;
using Domain.Common;
using Domain.Users.Entities;
using Domain.Users.Errors;
using Domain.Users.Repositories;
using Mediator;

namespace Application.Users.Commands.CreateUser;

public sealed class CreateUserCommandHandler(IUserWriteRepository userRepository, IUnitOfWork unitOfWork) : ICommandHandler<CreateUserCommand, Result<Guid>>
{
    public async Task<Result<Guid>> HandleAsync(CreateUserCommand command, CancellationToken cancellationToken = default)
    {
        if (await userRepository.ExistsByUsernameAsync(command.Username.ToUpperInvariant(), cancellationToken))
            return Result<Guid>.Failure(UserErrors.UsernameAlreadyExists);

        var result = User.Create(command.Username, command.Age);

        if (result.IsFailure)
            return Result<Guid>.Failure(result.Errors);

        await userRepository.AddAsync(result.Value!, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return await Task.FromResult(Result<Guid>.Success(result.Value!.Id));
    }
}