using Domain.Common;

namespace Domain.Users.Errors;

public sealed record DomainUserErrorCode(string Value) : DomainErrorCode(Value)
{
    public static readonly DomainUserErrorCode UsernameEmpty =
        new("user.username.empty");

    public static readonly DomainUserErrorCode UsernameTooSoon =
        new("user.username.too_soon");

    public static readonly DomainUserErrorCode AgeInvalid =
        new("user.age.invalid");

    public static readonly DomainUserErrorCode UsernameAlreadyExists =
        new("user.username.already_exists");
}