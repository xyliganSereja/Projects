using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Systems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class GotoCommand : ICommand
{
    private readonly string _path;

    public GotoCommand(string path)
    {
        _path = path;
    }

    public void Execute(ISystem system)
    {
        if (system is null)
        {
            throw new MySystemException("System is null");
        }

        if (Between('A', 'Z', _path[0]) && _path[1] == ':')
        {
            system.FindDirectory(_path.Substring(2));
        }
        else
        {
            system.CurrDirectory?.FindDirectory(_path);
        }
    }

    private static bool Between(char begin, char end, char ch)
    {
        return ch >= begin && ch <= end;
    }
}