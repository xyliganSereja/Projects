using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class ParserException : Exception
{
    public ParserException()
        : base("Parse error")
    {
    }

    public ParserException(string message)
        : base(message)
    {
    }

    public ParserException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}