using Application.Users.Errors;
using Domain.Abstractions;
using Domain.Users.Repositories;
using Mediator;
using Shared;

namespace Application.Users.Commands.UpdateUser;

public sealed class UpdateUserCommandHandler(IUserWriteRepository userRepository, IUnitOfWork unitOfWork) : ICommandHandler<UpdateUserCommand, Result>
{
    public async Task<Result> HandleAsync(UpdateUserCommand command, CancellationToken cancellationToken = default)
    {
        var user = await userRepository.LoadByIdAsync(command.UserId, cancellationToken);
        if (user is null)
            return Result.Failure(ApplicationUserError.UserNotFound);

        var updateResult = user.Update(
            command.Username,
            command.Age
            );

        if (updateResult.IsFailure)
            return updateResult;

        await userRepository.UpdateAsync(user, cancellationToken);

        try
        {
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
        catch (Exception)
        {
            // Transform exception to a domain-specific error if needed
        }

        return Result.Success();
    }
}
