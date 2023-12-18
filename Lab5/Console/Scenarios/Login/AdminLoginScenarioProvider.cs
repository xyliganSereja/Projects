using System.Diagnostics.CodeAnalysis;
using Contracts.Users;
using Models.Users;

namespace Console.Scenarios.Login;

public class AdminLoginScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentUser;

    public AdminLoginScenarioProvider(
        IUserService service,
        ICurrentUserService currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is not null && _currentUser.Role != UserRole.Admin)
        {
            scenario = null;
            return false;
        }

        scenario = new AdminLoginScenario(_service);
        return true;
    }
}