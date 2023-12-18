using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FilePackage;
using Itmo.ObjectOrientedProgramming.Lab4.Systems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileRenameCommand : ICommand
{
    private readonly string _path;
    private readonly string _newName;

    public FileRenameCommand(string path, string newName)
    {
        _path = path;
        _newName = newName;
    }

    public void Execute(ISystem system)
    {
        IFile? file;
        if (system is null)
        {
            throw new MySystemException("System is null");
        }

        if (Between('A', 'Z', _path[0]) && _path[1] == ':')
        {
            file = system.FindFile(_path.Substring(2))?.Clone();
        }
        else
        {
            file = system.CurrDirectory?.FindFile(_path)?.Clone();
        }

        if (file is null)
        {
            throw new MySystemException("File not found");
        }

        file.Rename(_newName);
    }

    private static bool Between(char begin, char end, char ch)
    {
        return ch >= begin && ch <= end;
    }
}