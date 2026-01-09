using Shared;

namespace Application.Common;

public abstract record ApplicationErrorCode : ErrorCode
{
    public ApplicationErrorCode(string value) : base(value) { }
}
public sealed record ApplicationError : Error
{
    public ApplicationError(ApplicationErrorCode code, string message) : base(code, message) { }
}
