using Contracts.Users;
using Spectre.Console;

namespace Console.Scenarios.User;

public class ShowBalanceScenario : IScenario
{
    private readonly ICurrentUserService _currentUser;

    public ShowBalanceScenario(
        ICurrentUserService userService)
    {
        _currentUser = userService;
    }

    public string Name => "Show balance";

    public void Run()
    {
        if (_currentUser.User is null)
        {
            throw new ArgumentNullException();
        }

#pragma warning disable CA1305
        AnsiConsole.WriteLine(_currentUser.User.Balance);
#pragma warning restore CA1305
        AnsiConsole.Ask<string>("Ok");
        AnsiConsole.Clear();
    }
}