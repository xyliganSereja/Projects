using Contracts.Users;
using Spectre.Console;

namespace Console.Scenarios.Login;

public class LogoutScenario : IScenario
{
    private readonly IUserService _userService;

    public LogoutScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Logout";

    public void Run()
    {
        _userService.Logout();
        AnsiConsole.Ask<string>("Ok");
    }
}