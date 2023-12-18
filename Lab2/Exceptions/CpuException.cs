using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class CpuException : Exception
{
    public CpuException()
        : base("Unsupported CPU type")
    {
    }

    public CpuException(string message)
        : base(message)
    {
    }

    public CpuException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}