using Domain.Common;

namespace Domain.Entities;

public class User
{   
    public Guid Id { get; init; } = Guid.NewGuid();
    private DateTime _createdAt { get; init; } = DateTime.UtcNow;

    public string Username { get; private set; } = string.Empty;
    private DateTime _usernameLastUpdated { get; set; } = default;

    public int Age { get; private set; } = 0;

    public static Result<User> Create(string username, int age)
    {
        Result result;
        var user = new User();
        result = user.UpdateUsername(username);
        if (!result.IsSuccess)
            return Result<User>.Failure(result.Message);
        result = user.UpdateAge(age);
        if (!result.IsSuccess)
            return Result<User>.Failure(result.Message);
        return Result<User>.Success(user);
    }

    public Result UpdateUsername(string newUsername)
    {
        if (string.IsNullOrWhiteSpace(newUsername))
            return Result.Failure("Username cannot be null or empty.");

        if (_usernameLastUpdated != default && (DateTime.UtcNow - _usernameLastUpdated).TotalDays < 30)
            return Result.Failure("Username can only be changed once every 30 days.");

        Username = newUsername.ToUpperInvariant();
        _usernameLastUpdated = DateTime.UtcNow;

        return Result.Success("Username updated successfully.");
    }

    public Result UpdateAge(int newAge)
    {
        var validationResult = ValidateAge(newAge);
        if (!validationResult.IsSuccess)
            return validationResult;
        Age = newAge;
        return Result.Success("Age updated successfully.");
    }

    private static Result ValidateAge(int age)
    {
        if (age < 18 || age > 100)
            return Result.Failure("Age must be between 18 and 100.");
        return Result.Success();
    }
}