using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.MyVisitor;
using Itmo.ObjectOrientedProgramming.Lab4.Printers;
using Itmo.ObjectOrientedProgramming.Lab4.Systems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class LsCommand : ICommand
{
    private readonly int? _depth;

    public LsCommand(int? depth)
    {
        _depth = depth;
    }

    public LsCommand()
    {
    }

    public void Execute(ISystem system)
    {
        if (system is null)
        {
            throw new MySystemException("System is null");
        }

        var sb = new StringBuilder();
        if (_depth is null)
        {
            sb.Append(Shower.Show(system.CurrDirectory, 0));
        }
        else
        {
            sb.Append(Shower.Show(system.CurrDirectory, 0, _depth.Value));
        }

        IPrinter printer = new ConsolePrinter();
        printer.Print(sb.ToString());
    }
}
