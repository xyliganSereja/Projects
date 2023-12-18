using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class MySystemException : Exception
{
    public MySystemException()
        : base("Unsupported system")
    {
    }

    public MySystemException(string message)
        : base(message)
    {
    }

    public MySystemException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}