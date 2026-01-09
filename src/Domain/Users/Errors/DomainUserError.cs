using Domain.Common;

namespace Domain.Users.Errors;

public static class DomainUserError
{
    public static DomainError UsernameCannotBeEmpty =>
        new (DomainUserErrorCode.UsernameEmpty, "Username cannot be null or empty.");

    public static DomainError UsernameChangeTooFrequent =>
        new (DomainUserErrorCode.UsernameTooSoon, "Username can only be changed once every 30 days.");

   public static DomainError AgeMustBeBetween18And100 =>
        new(DomainUserErrorCode.AgeInvalid, "Age must be between 18 and 100.");

    public static DomainError UsernameAlreadyExists =>
        new(DomainUserErrorCode.UsernameAlreadyExists, "Username already exists.");
}
