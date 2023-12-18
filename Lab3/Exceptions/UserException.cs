using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class UserException : Exception
{
    public UserException()
        : base("User is null")
    {
    }

    public UserException(string message)
        : base(message)
    {
    }

    public UserException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}