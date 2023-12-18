using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class MessageException : ArgumentNullException
{
    public MessageException()
        : base("Message is null")
    {
    }

    public MessageException(string message)
        : base(message)
    {
    }

    public MessageException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}