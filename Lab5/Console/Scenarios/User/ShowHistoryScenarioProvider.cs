using System.Diagnostics.CodeAnalysis;
using Abstractions;
using Contracts.Users;
using Models.Users;

namespace Console.Scenarios.User;

public class ShowHistoryScenarioProvider : IScenarioProvider
{
    private readonly ICurrentUserService _currentUser;
    private readonly IOperationRepository _operationRepository;

    public ShowHistoryScenarioProvider(
        IOperationRepository operationRepository,
        ICurrentUserService currentUser)
    {
        _operationRepository = operationRepository;
        _currentUser = currentUser;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is null || _currentUser.Role != UserRole.User)
        {
            scenario = null;
            return false;
        }

        scenario = new ShowHistoryScenario(_operationRepository, _currentUser);
        return true;
    }
}