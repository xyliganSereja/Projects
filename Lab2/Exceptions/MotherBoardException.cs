using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class MotherBoardException : Exception
{
    public MotherBoardException()
        : base("Motherboard exception")
    {
    }

    public MotherBoardException(string message)
        : base(message)
    {
    }

    public MotherBoardException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}