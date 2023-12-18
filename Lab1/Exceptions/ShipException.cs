using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class ShipException : Exception
{
    public ShipException()
        : base("Smth happened")
    {
    }

    public ShipException(string message)
        : base(message)
    {
    }

    public ShipException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}