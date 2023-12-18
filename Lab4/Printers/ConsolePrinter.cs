using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Printers;

public class ConsolePrinter : IPrinter
{
    public void Print(string str)
    {
        Console.WriteLine(str);
    }
}