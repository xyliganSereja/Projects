using System.Diagnostics.CodeAnalysis;
using Abstractions;
using Contracts.Users;
using Models.Users;

namespace Console.Scenarios.User;

public class AddMoneyScenarioProvider : IScenarioProvider
{
    private readonly ICurrentUserService _currentUser;
    private readonly IUserRepository _userRepository;

    public AddMoneyScenarioProvider(
        IUserRepository userRepository,
        ICurrentUserService currentUser)
    {
        _userRepository = userRepository;
        _currentUser = currentUser;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is null || _currentUser.Role != UserRole.User)
        {
            scenario = null;
            return false;
        }

        scenario = new AddMoneyScenario(_currentUser, _userRepository);
        return true;
    }
}