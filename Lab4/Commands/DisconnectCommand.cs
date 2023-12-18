using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Systems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class DisconnectCommand : ICommand
{
    public void Execute(ISystem system)
    {
        if (system is null)
        {
            throw new MySystemException("System is null");
        }

        system.DisconnectSystem();
    }
}