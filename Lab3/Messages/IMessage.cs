namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public interface IMessage : IFormattable
{
    public string Title { get; }
    public string Body { get; }
    public int Priority { get; }
}