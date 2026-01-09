using Shared;

namespace Domain.Common;

public abstract record DomainErrorCode : ErrorCode
{
    public DomainErrorCode(string value) : base(value) { }
}
public sealed record DomainError: Error
{
    public DomainError(DomainErrorCode code, string message) : base(code, message) { }
}