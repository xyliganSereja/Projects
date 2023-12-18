using System;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public class ConsoleMessenger : IMessenger
{
    private IMessage? _message;
    public ConsoleMessenger()
    {
        Logger = new ConsoleLogger();
    }

    public ConsoleLogger Logger { get; }

    public void AddMessage(IMessage message)
    {
        _message = message;
    }

    public void Print()
    {
        if (_message is null)
        {
            throw new MessageException("Message is null");
        }

        Logger.Log(_message.Format());
        Logger.Log();
        Console.WriteLine(Logger.ConsoleLog);
    }
}