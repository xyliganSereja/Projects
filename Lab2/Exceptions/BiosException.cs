using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class BiosException : Exception
{
    public BiosException()
        : base("Unsupported Bios type")
    {
    }

    public BiosException(string message)
        : base(message)
    {
    }

    public BiosException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}