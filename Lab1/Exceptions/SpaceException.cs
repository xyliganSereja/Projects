using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class SpaceException : Exception
{
    public SpaceException()
        : base("Unknown type of space")
    {
    }

    public SpaceException(string message)
        : base(message)
    {
    }

    public SpaceException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}