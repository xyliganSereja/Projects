using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class ReadMessageException : Exception
{
    public ReadMessageException()
        : base("You can't read the message you've read")
    {
    }

    public ReadMessageException(string message)
        : base(message)
    {
    }

    public ReadMessageException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}