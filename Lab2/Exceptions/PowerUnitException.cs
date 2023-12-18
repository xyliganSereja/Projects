using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class PowerUnitException : Exception
{
    public PowerUnitException()
        : base("Unsupported PowerUnit type")
    {
    }

    public PowerUnitException(string message)
        : base(message)
    {
    }

    public PowerUnitException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}