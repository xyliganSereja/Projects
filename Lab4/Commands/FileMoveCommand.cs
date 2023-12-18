using Itmo.ObjectOrientedProgramming.Lab4.DirectoryPackage;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FilePackage;
using Itmo.ObjectOrientedProgramming.Lab4.Systems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileMoveCommand : ICommand
{
    private readonly string _from;
    private readonly string _to;

    public FileMoveCommand(string from, string to)
    {
        _from = from;
        _to = to;
    }

    public void Execute(ISystem system)
    {
        if (system is null)
        {
            throw new MySystemException("system is null");
        }

        IFile? file;
        if (Between('A', 'Z', _from[0]) && _from[1] == ':')
        {
            file = system.FindFile(_from.Substring(2));
        }
        else
        {
            file = system.CurrDirectory?.FindFile(_from);
        }

        IDirectory? directory;
        if (Between('A', 'Z', _to[0]) && _to[1] == ':')
        {
            directory = system.FindDirectory(_to.Substring(2));
        }
        else
        {
            directory = system.CurrDirectory?.FindDirectory(_to);
        }

        if (directory is null || file is null)
        {
            throw new MySystemException("file or directory is null");
        }

        directory.AddFile(file);
        var command = new FileDeleteCommand(_to);
        command.Execute(system);
    }

    private static bool Between(char begin, char end, char ch)
    {
        return ch >= begin && ch <= end;
    }
}