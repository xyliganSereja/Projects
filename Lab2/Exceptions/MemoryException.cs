using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class MemoryException : Exception
{
    public MemoryException()
        : base("Unsupported memory type")
    {
    }

    public MemoryException(string message)
        : base(message)
    {
    }

    public MemoryException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}