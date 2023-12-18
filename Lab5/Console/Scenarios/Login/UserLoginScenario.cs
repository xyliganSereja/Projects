using Contracts;
using Contracts.Users;
using Spectre.Console;

namespace Console.Scenarios.Login;

public class UserLoginScenario : IScenario
{
    private readonly IUserService _userService;

    public UserLoginScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "User login";

    public void Run()
    {
        long userId = AnsiConsole.Ask<long>("Enter your user id");
        long userPassword = AnsiConsole.Ask<long>("Enter your user password");
        LoginResult result = _userService.Login(userId, userPassword);

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