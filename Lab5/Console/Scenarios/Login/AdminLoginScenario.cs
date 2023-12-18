using Contracts;
using Contracts.Users;
using Spectre.Console;

namespace Console.Scenarios.Login;

public class AdminLoginScenario : IScenario
{
    private readonly IUserService _userService;

    public AdminLoginScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Admin login";

    public void Run()
    {
        string name = AnsiConsole.Ask<string>("Enter your admin name");
        string password = AnsiConsole.Ask<string>("Enter your admin password");
        LoginResult result = _userService.LoginAdmin(name, password);

        string message = result switch
        {
            LoginResult.Success => "Successful login",
            LoginResult.WrongPassword => "Wrong password",
            LoginResult.NotFound => "User not found",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
        AnsiConsole.Clear();
    }
}