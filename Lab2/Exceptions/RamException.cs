using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class RamException : Exception
{
    public RamException()
        : base("RAM exception")
    {
    }

    public RamException(string message)
        : base(message)
    {
    }

    public RamException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}