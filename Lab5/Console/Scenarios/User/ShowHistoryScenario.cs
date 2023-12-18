using Abstractions;
using Contracts.Users;
using Models.Operations;
using Spectre.Console;

namespace Console.Scenarios.User;

public class ShowHistoryScenario : IScenario
{
    private readonly IOperationRepository _operationRepository;
    private readonly ICurrentUserService _currentUser;

    public ShowHistoryScenario(
        IOperationRepository operationRepository,
        ICurrentUserService userService)
    {
        _operationRepository = operationRepository;
        _currentUser = userService;
    }

    public string Name => "Show history";

    public void Run()
    {
        if (_currentUser.User is null)
        {
            throw new ArgumentNullException();
        }

        foreach (Operation operation in _operationRepository.GetOperationsByUserId(_currentUser.User.Id))
        {
            AnsiConsole.WriteLine(operation.ToString());
        }

        AnsiConsole.Ask<string>("Ok");
        AnsiConsole.Clear();
    }
}