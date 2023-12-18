using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class XmpException : Exception
{
    public XmpException()
        : base("Unsupported CPU type")
    {
    }

    public XmpException(string message)
        : base(message)
    {
    }

    public XmpException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}