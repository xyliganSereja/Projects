using Itmo.ObjectOrientedProgramming.Lab3.Destinations;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics;

public interface ITopic
{
    public string Name { get; }
    public IDestination Destination { get; }

    void SendMessage(Message message);
}