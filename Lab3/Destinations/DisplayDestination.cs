using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations;

public class DisplayDestination : IDestination
{
    private readonly ConsoleLogger _logger;

    public DisplayDestination()
    {
        Display = Displays.Display.ConsoleDisplay();
        _logger = new ConsoleLogger();
    }

    public DisplayDestination(Display display)
    {
        Display = display;
        _logger = new ConsoleLogger();
    }

    private IDisplay Display { get; }

    public string LogTime()
    {
        return _logger.GetInfo();
    }

    public void SendMessage(IMessage message)
    {
        if (message is null)
        {
            throw new MessageException("Message is null");
        }

        Display.AddText(message.Format());
    }
}