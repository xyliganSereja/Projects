using Itmo.ObjectOrientedProgramming.Lab4.DirectoryPackage;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FilePackage;
using Itmo.ObjectOrientedProgramming.Lab4.Systems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileDeleteCommand : ICommand
{
    private readonly string _path;

    public FileDeleteCommand(string path)
    {
        _path = path;
    }

    public void Execute(ISystem system)
    {
        IDirectory? directory;
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

        if (Between('A', 'Z', _path[0]) && _path[1] == ':')
        {
            directory = system.FindDirectory(_path.Substring(2, _path.Length - file.Name.Length - 1));
        }
        else
        {
            directory = system.CurrDirectory?.FindDirectory(_path.Substring(0, _path.Length - file.Name.Length - 1));
        }

        directory?.DeleteDirectory(file.Name);
    }

    private static bool Between(char begin, char end, char ch)
    {
        return ch >= begin && ch <= end;
    }
}