using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class ComputerException : Exception
{
    public ComputerException()
        : base("Unsupported Computer type")
    {
    }

    public ComputerException(string message)
        : base(message)
    {
    }

    public ComputerException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}