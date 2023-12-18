using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class VideoCardException : Exception
{
    public VideoCardException()
        : base("VideoCard exception")
    {
    }

    public VideoCardException(string message)
        : base(message)
    {
    }

    public VideoCardException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}