using Itmo.ObjectOrientedProgramming.Lab3.Destinations;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics;

public class Topic : ITopic
{
    public Topic(string name, IDestination destination)
    {
        Name = name;
        Destination = destination;
    }

    public string Name { get; }
    public IDestination Destination { get; }

    public void SendMessage(Message message)
    {
        Destination.SendMessage(message);
    }
}