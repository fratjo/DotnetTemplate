namespace Shared;

public abstract record ResultBase
{
    public IReadOnlyList<Error> Errors { get; init; } = Array.Empty<Error>();
    public bool IsSuccess => Errors.Count == 0;
    public bool IsFailure => !IsSuccess;
}

public record Result : ResultBase
{
    public static Result Success() => new();
    public static Result Failure(params Error[] errors) => new Result { Errors = errors };
}
public record Result<T> : ResultBase
{
    public T? Value { get; init; }

    public static Result<T> Success(T value)
        => new() { Value = value };

    public static Result<T> Failure(params Error[] errors)
        => new() { Errors = errors };

    public static Result<T> Failure(IEnumerable<Error> errors)
        => new() { Errors = errors.ToArray() };

    public Result ToResult()
    {
        return new Result
        {
            Errors = this.Errors
        };
    }
}
