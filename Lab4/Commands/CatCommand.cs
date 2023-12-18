using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FilePackage;
using Itmo.ObjectOrientedProgramming.Lab4.Printers;
using Itmo.ObjectOrientedProgramming.Lab4.Systems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class CatCommand : ICommand
{
    private readonly IPrinter _printer;
    private readonly string _path;

    public CatCommand(string path)
    {
        _printer = new ConsolePrinter();
        _path = path;
    }

    public CatCommand(string path, string mode)
    {
        if (mode != "console")
        {
            throw new PrinterException("Unsupported printer");
        }

        _printer = new ConsolePrinter();
        _path = path;
    }

    public void Execute(ISystem system)
    {
        if (system is null)
        {
            throw new MySystemException("System is null");
        }

        IFile? file = system.FindFile(_path);
        _printer.Print(file?.ToString() ?? "File not found");
    }
}