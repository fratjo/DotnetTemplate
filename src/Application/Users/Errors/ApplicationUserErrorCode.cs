using Application.Common;

namespace Application.Users.Errors;

public sealed record ApplicationUserErrorCode(string Value) : ApplicationErrorCode(Value)
{
    public static readonly ApplicationUserErrorCode UserNotFound =
        new("user.not_found");
}