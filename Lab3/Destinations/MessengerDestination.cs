using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations;

public class MessengerDestination : IDestination
{
    public MessengerDestination()
    {
        ConsoleMessenger = new ConsoleMessenger();
    }

    public MessengerDestination(ConsoleMessenger consoleMessenger)
    {
        ConsoleMessenger = consoleMessenger;
    }

    private ConsoleMessenger ConsoleMessenger { get; }

    public void SendMessage(IMessage message)
    {
        if (message is null)
        {
            throw new MessageException("Message is null");
        }

        ConsoleMessenger.AddMessage(message);
    }
}