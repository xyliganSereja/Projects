namespace Contracts;

public abstract record LoginResult
{
    private LoginResult() { }

#pragma warning disable CA1034
    public sealed record Success : LoginResult;

    public sealed record WrongPassword : LoginResult;

    public sealed record NotFound : LoginResult;
#pragma warning restore CA1034
}