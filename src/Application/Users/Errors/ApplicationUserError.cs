using Application.Common;

namespace Application.Users.Errors;

public static class ApplicationUserError
{
    public static ApplicationError UserNotFound =>
        new(ApplicationUserErrorCode.UserNotFound, "User not found.");
}
