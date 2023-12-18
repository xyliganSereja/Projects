using System.Diagnostics.CodeAnalysis;
using Contracts.Users;
using Models.Users;

namespace Console.Scenarios.User;

public class ShowBalanceScenarioProvider : IScenarioProvider
{
    private readonly ICurrentUserService _currentUser;

    public ShowBalanceScenarioProvider(
        ICurrentUserService currentUser)
    {
        _currentUser = currentUser;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is null || _currentUser.Role != UserRole.User)
        {
            scenario = null;
            return false;
        }

        scenario = new ShowBalanceScenario(_currentUser);
        return true;
    }
}