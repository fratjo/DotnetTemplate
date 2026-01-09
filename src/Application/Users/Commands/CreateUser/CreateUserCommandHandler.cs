using Domain.Abstractions;
using Domain.Users.Entities;
using Domain.Users.Errors;
using Domain.Users.Repositories;
using Mediator;
using Shared;

namespace Application.Users.Commands.CreateUser;

public sealed class CreateUserCommandHandler(IUserWriteRepository userRepository, IUnitOfWork unitOfWork) : ICommandHandler<CreateUserCommand, Result<Guid>>
{
    public async Task<Result<Guid>> HandleAsync(CreateUserCommand command, CancellationToken cancellationToken = default)
    {
        if (await userRepository.ExistsByUsernameAsync(command.Username.ToUpperInvariant(), cancellationToken))
            return Result<Guid>.Failure(DomainUserError.UsernameAlreadyExists);

        var result = User.Create(command.Username, command.Age);

        if (result.IsFailure)
            return Result<Guid>.Failure(result.Errors);

        await userRepository.AddAsync(result.Value!, cancellationToken);
        
        try
        {
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
        catch (Exception)
        {
            // Log the exception (not implemented here for brevity)
        }

        return await Task.FromResult(Result<Guid>.Success(result.Value!.Id));
    }
}