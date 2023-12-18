using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Users;

namespace Itmo.ObjectOrientedProgramming.Lab3.Proxy;

public class MessagePriorityProxy : IMessagePriorityProxy
{
    private readonly IUser _user;
    private readonly int _priority;
    public MessagePriorityProxy(int priority)
    {
        Logger = new CountingLogger();
        _user = new User();
        _priority = priority;
    }

    public ILogger Logger { get; }

    public void Receive(IMessage message)
    {
        if (message is null)
        {
            throw new MessageException("Message is null");
        }

        if (message.Priority <= _priority)
        {
            _user.ReceiveMessage(message);
            Logger.Log();
        }
    }
}