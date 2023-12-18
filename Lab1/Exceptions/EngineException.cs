using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class EngineException : Exception
{
    public EngineException()
        : base("Exception in engine")
    {
    }

    public EngineException(string message)
        : base(message)
    {
    }

    public EngineException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}