using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public class FileMessenger : IMessenger
{
    private readonly string _fileName;
    private IMessage? _message;

    public FileMessenger(string fileName)
    {
        _fileName = fileName;
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

        if (_fileName is null)
        {
            throw new MessageException("File name is null");
        }

        try
        {
            var writer = new StreamWriter(_fileName);
            Logger.Log(_message.Format());
            writer.WriteLine("Messenger: " + _message.Format());
            writer.Close();
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("File not found" + e.Message + e.StackTrace);
        }
    }
}