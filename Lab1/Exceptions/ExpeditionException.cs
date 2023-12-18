using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class ExpeditionException : Exception
{
    public ExpeditionException()
        : base("Wrong expedition")
    {
    }

    public ExpeditionException(string message)
        : base(message)
    {
    }

    public ExpeditionException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}