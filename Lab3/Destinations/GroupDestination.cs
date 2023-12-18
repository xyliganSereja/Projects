using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Users;

namespace Itmo.ObjectOrientedProgramming.Lab3.Destinations;

public class GroupDestination : IDestination
{
    private readonly List<IUser> _users;

    public GroupDestination()
    {
        _users = new List<IUser>();
    }

    public GroupDestination(params User[] users)
    {
        if (users is null)
        {
            throw new UserException("group of users are null");
        }

        _users = new List<IUser>();
        foreach (User user in users)
        {
            _users.Add(user);
        }
    }

    public void AddUser()
    {
        _users.Add(new User());
    }

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public void SendMessage(IMessage message)
    {
        foreach (IUser user in _users)
        {
            user.ReceiveMessage(message);
        }
    }
}