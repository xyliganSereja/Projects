using System.Diagnostics.CodeAnalysis;
using Contracts.Users;

namespace Console.Scenarios.Login;

public class LogoutScenarioProvider : IScenarioProvider
{
    private readonly IUserService _currentUser;

    public LogoutScenarioProvider(IUserService currentUser)
    {
        _currentUser = currentUser;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new LogoutScenario(_currentUser);
        return true;
    }
}