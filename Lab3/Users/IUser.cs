using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public interface IUser
{
    void Read(int index);
    void ReceiveMessage(IMessage message);
    bool MessageWasRead(int index);
}