namespace Shared;

public abstract record ErrorCode(string Value);

public abstract record Error(ErrorCode Code, string Message);
