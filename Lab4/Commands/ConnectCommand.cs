using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Systems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ConnectCommand : ICommand
{
    private readonly string _name;
    private readonly string _mode;

    public ConnectCommand(string name, string mode)
    {
        _name = name;
        _mode = mode;
    }

    public void Execute(ISystem system)
    {
        if (system is null)
        {
            throw new MySystemException("System is null");
        }

        system.ConnectSystem(_name, _mode);
    }
}