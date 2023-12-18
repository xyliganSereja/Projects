using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class PrinterException : Exception
{
    public PrinterException()
        : base("Print error")
    {
    }

    public PrinterException(string message)
        : base(message)
    {
    }

    public PrinterException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}