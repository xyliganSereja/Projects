using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Users;

namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations;

public class UserDestination : IDestination
{
    private readonly User _user;

    public UserDestination()
    {
        _user = new User();
    }

    public void SendMessage(IMessage message)
    {
        _user.ReceiveMessage(message);
    }
}