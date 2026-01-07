namespace Application.Common;

public abstract class Maybe<T>
{
    // If value is null, return None<T>
    public static Maybe<T> Some(T value) => value is null ? None() : new Some<T>(value);
    public static Maybe<T> None() => None<T>.Instance;
}

public sealed class Some<T> : Maybe<T>
{
    public T Value { get; }
    internal Some(T value) 
    {
        Value = value;
    }
}

public sealed class None<T> : Maybe<T>
{
    internal static readonly None<T> Instance = new None<T>();
    private None() { }
}