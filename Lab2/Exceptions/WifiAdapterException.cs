using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class WifiAdapterException : Exception
{
    public WifiAdapterException()
        : base("Unsupported Box type")
    {
    }

    public WifiAdapterException(string message)
        : base(message)
    {
    }

    public WifiAdapterException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}