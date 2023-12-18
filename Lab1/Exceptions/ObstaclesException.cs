using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class ObstaclesException : Exception
{
    public ObstaclesException()
        : base("Unknown type of obstacle")
    {
    }

    public ObstaclesException(string message)
        : base(message)
    {
    }

    public ObstaclesException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}