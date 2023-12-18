using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class ScannerException : Exception
{
    public ScannerException()
        : base("Scanner is null")
    {
    }

    public ScannerException(string message)
        : base(message)
    {
    }

    public ScannerException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}