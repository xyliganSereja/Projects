using System.Diagnostics.CodeAnalysis;
using Abstractions;
using Contracts.Users;
using Models.Users;

namespace Console.Scenarios.Admin;

public class AddUserScenarioProvider : IScenarioProvider
{
    private readonly IUserRepository _userRepository;
    private readonly ICurrentUserService _currentUser;

    public AddUserScenarioProvider(
        IUserRepository userRepository,
        ICurrentUserService currentUser)
    {
        _userRepository = userRepository;
        _currentUser = currentUser;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is not null || _currentUser.Role != UserRole.Admin)
        {
            scenario = null;
            return false;
        }

        scenario = new AddUserScenario(_userRepository);
        return true;
    }
}