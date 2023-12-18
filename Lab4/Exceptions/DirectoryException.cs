using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class DirectoryException : Exception
{
    public DirectoryException()
        : base("Unsupported directory type")
    {
    }

    public DirectoryException(string message)
        : base(message)
    {
    }

    public DirectoryException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}