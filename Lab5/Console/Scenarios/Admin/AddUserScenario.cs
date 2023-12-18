using Abstractions;
using Spectre.Console;

namespace Console.Scenarios.Admin;

public class AddUserScenario : IScenario
{
    private readonly IUserRepository _userRepository;

    public AddUserScenario(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public string Name => "Add user";

    public void Run()
    {
        long id = AnsiConsole.Ask<long>("Enter user id");
        long password = AnsiConsole.Ask<long>("Enter user id");

        if (_userRepository.FindUserById(id) is not null)
        {
            AnsiConsole.WriteLine("User already exist");
        }
        else
        {
            _userRepository.InsertUser(id, password);
        }

        AnsiConsole.Ask<string>("Ok");
        AnsiConsole.Clear();
    }
}