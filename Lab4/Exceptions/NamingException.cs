using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class NamingException : Exception
{
    public NamingException()
        : base("Unsupported name")
    {
    }

    public NamingException(string message)
        : base(message)
    {
    }

    public NamingException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}