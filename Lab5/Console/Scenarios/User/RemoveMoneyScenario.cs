using Abstractions;
using Contracts.Users;
using Spectre.Console;

namespace Console.Scenarios.User;

public class RemoveMoneyScenario : IScenario
{
    private readonly ICurrentUserService _userService;
    private readonly IUserRepository _userRepository;

    public RemoveMoneyScenario(ICurrentUserService userService, IUserRepository userRepository)
    {
        _userService = userService;
        _userRepository = userRepository;
    }

    public string Name => "Remove money";

    public void Run()
    {
        decimal amount = AnsiConsole.Ask<decimal>("Enter amount");

        if (_userService.User is null)
        {
            throw new ArgumentNullException();
        }

        if (amount > 0)
        {
            AnsiConsole.WriteLine("Amount can not be above zero");
        }
        else if (_userService.User.Balance < amount)
        {
            AnsiConsole.WriteLine("Balance can not be below zero");
        }
        else
        {
            _userRepository.AddMoney(_userService.User.Id, amount);
        }

        AnsiConsole.Ask<string>("Ok");
        AnsiConsole.Clear();
    }
}