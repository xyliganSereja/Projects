using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class FileException : Exception
{
    public FileException()
        : base("Unsupported file type")
    {
    }

    public FileException(string message)
        : base(message)
    {
    }

    public FileException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}