using System;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers;

public class ConsoleLogger : ILogger
{
    public string? ConsoleLog { get; private set; }
    public void Log(string message)
    {
        ConsoleLog = message;
    }

    public void Log()
    {
        ConsoleLog = GetInfo() + ConsoleLog;
    }

    public string GetInfo()
    {
        if (ConsoleLog is null)
        {
            throw new MessageException("Message is null");
        }

        return DateTime.Today.ToLongDateString();
    }
}