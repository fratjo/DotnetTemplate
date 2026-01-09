using Domain.Common;
using Domain.Users.Errors;
using Shared;
using System.Diagnostics;

namespace Domain.Users.Entities;

public class User
{
    #region Properties
    public Guid Id { get; init; } = Guid.NewGuid();
    private DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    public string Username { get; private set; } = string.Empty;
    private DateTime UsernameLastUpdated { get; set; } = default;

    public int Age { get; private set; } = 0;
    #endregion  

    #region Constructor
    private User(string username, int age, DateTime createdAt) 
    {
        Username = username.ToUpperInvariant();
        UsernameLastUpdated = createdAt;
        Age = age;
    }
    #endregion

    #region Factory Method
    public static Result<User> Create(string username, int age)
    {
        var now = DateTime.UtcNow;

        var errors = ValidateCreate(username, age, now);

        if (errors.Any())
            return Result<User>.Failure([.. errors]);

        var user = ApplyCreate(username, age, now);

        return Result<User>.Success(user);
    }
    #endregion

    #region Update Method
    public Result Update(string? username, int? age)
    {
        var now = DateTime.UtcNow;

        var errors = ValidateUpdate(username, age, now);

        if (errors.Any())
            return Result.Failure([.. errors]);

        ApplyUpdate(username, age, now);

        return Result.Success();
    }
    #endregion

    #region Apply Methods
    private static User ApplyCreate(string username, int age, DateTime now)
    {
        return new User(
            username.ToUpperInvariant(),
            age,
            now
        );
    }

    private void ApplyUpdate(string? username, int? age, DateTime now)
    {
        if (username is not null)
        {
            Username = username.ToUpperInvariant();
            UsernameLastUpdated = now;
        }

        if (age is not null)
        {
            Age = age.Value;
        }
    }
    #endregion

    #region Validation Methods
    private static IEnumerable<DomainError> ValidateCreate(string username, int age, DateTime now)
    {
        foreach (var error in ValidateUsername(username, null, now))
            yield return error;

        foreach (var error in ValidateAge(age))
            yield return error;
    }

    private IEnumerable<DomainError> ValidateUpdate(string? username, int? age, DateTime now)
    {
        if (username is not null)
        {
            foreach (var error in ValidateUsername(username, UsernameLastUpdated, now))
                yield return error;
        }

        if (age is not null)
        {
            foreach (var error in ValidateAge(age.Value))
                yield return error;
        }
    }

    private static IEnumerable<DomainError> ValidateUsername(string username, DateTime? lastUpdated, DateTime now)
    {
        if (string.IsNullOrWhiteSpace(username))
            yield return DomainUserError.UsernameCannotBeEmpty;
        if (lastUpdated.HasValue && (now - lastUpdated.Value).TotalDays < 30)
            yield return DomainUserError.UsernameChangeTooFrequent;
    }

    private static IEnumerable<DomainError> ValidateAge(int age)
    {
        if (age < 18 || age > 100)
            yield return DomainUserError.AgeMustBeBetween18And100;
    }
    #endregion
}