using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations;

public interface IDestination
{
    void SendMessage(IMessage message);
}