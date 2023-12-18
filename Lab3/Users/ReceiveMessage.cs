using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public class ReceiveMessage
{
    private readonly IMessage _message;
    private MessagesStatus _messageStatus;

    public ReceiveMessage(IMessage message)
    {
        _message = message;
        _messageStatus = MessagesStatus.Unread;
    }

    public void Read()
    {
        if (_message is null)
        {
            throw new MessageException("Message is null");
        }

        if (_messageStatus == MessagesStatus.Read)
        {
            throw new ReadMessageException();
        }

        _messageStatus = MessagesStatus.Read;
    }

    public bool WasRead()
    {
        return _messageStatus == MessagesStatus.Read;
    }
}