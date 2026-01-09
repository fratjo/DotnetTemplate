namespace Shared;

public abstract record Maybe<T>
{
    public static Maybe<T> Some(T value) => value is null ? None() : new Some<T>(value);
    public static Maybe<T> None() => None<T>.Instance;
    public abstract TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none);
}

public sealed record Some<T> : Maybe<T>
{
    public T Value { get; }
    internal Some(T value) => Value = value;
    public override TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none)
        => some(Value);
}

public sealed record None<T> : Maybe<T>
{
    internal static readonly None<T> Instance = new None<T>();
    private None() { }
    public override TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none)
        => none();
}