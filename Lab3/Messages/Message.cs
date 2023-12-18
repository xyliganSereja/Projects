using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class Message : IMessage
{
    public Message(string title, string body, int priority)
    {
        Title = title;
        Body = body;
        Priority = priority;
    }

    public Message(IMessage message)
    {
        if (message is null)
        {
            throw new MessageException("Message is null");
        }

        Title = message.Title;
        Body = message.Body;
        Priority = message.Priority;
    }

    public string Title { get; }
    public string Body { get; }
    public int Priority { get; }

    public string Format()
    {
        return $"\n{Title}\n{Body}";
    }
}
