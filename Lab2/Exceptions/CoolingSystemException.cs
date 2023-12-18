using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class CoolingSystemException : Exception
{
    public CoolingSystemException()
        : base("Unsupported CPU type")
    {
    }

    public CoolingSystemException(string message)
        : base(message)
    {
    }

    public CoolingSystemException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}