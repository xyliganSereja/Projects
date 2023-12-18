using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class BoxException : Exception
{
    public BoxException()
        : base("Unsupported Box type")
    {
    }

    public BoxException(string message)
        : base(message)
    {
    }

    public BoxException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}