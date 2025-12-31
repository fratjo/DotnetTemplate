using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Domain.Common;

public enum ErrorType
{
    None,
    BadRequest = 400,
    NotFound = 404,
    Unauthorized = 403,
    Conflict = 409,
    InternalServerError = 500
}

public abstract record ResultBase
{
    public bool IsSuccess { get; init; }
    public string? Message { get; init; }
    public ErrorType ErrorType { get; init; }
    public override string ToString()
    {
        return IsSuccess ? $"Success: {Message}" : $"Failure: {Message}";
    }
}

public record Result : ResultBase
{
    public static Result Success(string? message = null) => new Result { IsSuccess = true, Message = message };
    public static Result Failure(string? message = null) => new Result { IsSuccess = false, Message = message };
    public static Result BadRequest(string? message = null) => new Result { IsSuccess = false, Message = message ?? "Bad request.", ErrorType = ErrorType.BadRequest };
    public static Result Conflict(string? message = null) => new Result { IsSuccess = false, Message = message ?? "Bad request.", ErrorType = ErrorType.Conflict };
    public static Result NotFound(string? message = null) => new Result { IsSuccess = false, Message = message ?? "Resource not found.", ErrorType = ErrorType.NotFound };
    public static Result Unauthorized(string? message = null) => new Result { IsSuccess = false, Message = message ?? "Unauthorized access.", ErrorType = ErrorType.Unauthorized };
}
public record Result<T> : ResultBase
{
    public T? Value { get; init; }

    public static Result<T> Success(T value, string? message = null) => new Result<T> { IsSuccess = true, Message = message, Value = value };
    public static Result<T> Failure(string? message = null) => new Result<T> { IsSuccess = false, Message = message };
    public static Result<T> BadRequest(string? message = null) => new Result<T> { IsSuccess = false, Message = message ?? "Bad request.", ErrorType = ErrorType.BadRequest };
    public static Result<T> Conflict(string? message = null) => new Result<T> { IsSuccess = false, Message = message ?? "Bad request.", ErrorType = ErrorType.Conflict };
    public static Result<T> NotFound(string? message = null) => new Result<T> { IsSuccess = false, Message = message ?? "Resource not found.", ErrorType = ErrorType.NotFound };
    public static Result<T> Unauthorized(string? message = null) => new Result<T> { IsSuccess = false, Message = message ?? "Unauthorized access.", ErrorType = ErrorType.Unauthorized };

    // Convert generic Result<T> to non-generic Result, preserving status, message and error type.
    public Result ToResult()
    {
        return new Result
        {
            IsSuccess = this.IsSuccess,
            Message = this.Message,
            ErrorType = this.ErrorType
        };
    }
}
