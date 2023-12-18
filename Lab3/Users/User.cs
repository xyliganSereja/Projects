using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public class User : IUser
{
    private readonly List<ReceiveMessage> _receiveMessages;
    public User()
    {
        _receiveMessages = new List<ReceiveMessage>();
    }

    public void Read(int index)
    {
        if (index < 0 && index > _receiveMessages.Count)
        {
            throw new UserException($"Index 0 out of range {_receiveMessages.Count}");
        }

        _receiveMessages[index].Read();
    }

    public void ReceiveMessage(IMessage message)
    {
        _receiveMessages.Add(new ReceiveMessage(new Message(message)));
    }

    public bool MessageWasRead(int index)
    {
        if (index < 0 && index > _receiveMessages.Count)
        {
            throw new MessageException($"Index {index} out of range {_receiveMessages.Count}");
        }

        return _receiveMessages[index].WasRead();
    }
}