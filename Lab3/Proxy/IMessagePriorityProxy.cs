using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Proxy;

public interface IMessagePriorityProxy
{
    public void Receive(IMessage message);
}