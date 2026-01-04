using Domain.Common;
using Domain.Abstractions;
using Domain.Users.Repositories;
using Domain.Users.Errors;
using Mediator;

namespace Application.Users.Commands.UpdateUser;

public sealed class UpdateUserCommandHandler(IUserWriteRepository userRepository, IUnitOfWork unitOfWork) : ICommandHandler<UpdateUserCommand, Result>
{
    public async Task<Result> HandleAsync(UpdateUserCommand command, CancellationToken cancellationToken = default)
    {
        var user = await userRepository.LoadByIdAsync(command.UserId, cancellationToken);
        if (user is null)
            return Result.Failure(UserErrors.UserNotFound);
        
        if (command.Username is not null)
        {
            var updateResult = user.UpdateUsername(command.Username);
            if (!updateResult.IsSuccess)
                return updateResult;
        }

        if (command.Age is not null)
        {
            var updateResult = user.UpdateAge(command.Age.Value);
            if (!updateResult.IsSuccess)
                return updateResult;
        }

        await userRepository.UpdateAsync(user, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
