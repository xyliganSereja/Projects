using Abstractions;
using Contracts;
using Contracts.Users;
using Models.Users;

namespace Application.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly CurrentUserManager _currentUserManager;

    public UserService(IUserRepository repository, CurrentUserManager currentUserManager)
    {
        _repository = repository;
        _currentUserManager = currentUserManager;
    }

    public LoginResult Login(long id, long password)
    {
        User? user = _repository.FindUserById(id);

        if (user is null)
        {
            _currentUserManager.User = null;
            _currentUserManager.Role = UserRole.Unknown;
            return new LoginResult.NotFound();
        }

        if (user.Password != password)
        {
            _currentUserManager.User = null;
            _currentUserManager.Role = UserRole.Unknown;
            return new LoginResult.WrongPassword();
        }

        _currentUserManager.User = user;
        _currentUserManager.Role = UserRole.User;
        return new LoginResult.Success();
    }

    public LoginResult LoginAdmin(string name, string password)
    {
        switch (name)
        {
            case "admin":
            {
                switch (password)
                {
                    case "aboba":
                    {
                        _currentUserManager.Role = UserRole.Admin;
                        return new LoginResult.Success();
                    }

                    default:
                    {
                        _currentUserManager.Role = UserRole.Unknown;
                        return new LoginResult.WrongPassword();
                    }
                }
            }

            default:
            {
                _currentUserManager.Role = UserRole.Unknown;
                return new LoginResult.NotFound();
            }
        }
    }

    public void Logout()
    {
        _currentUserManager.User = null;
        _currentUserManager.Role = UserRole.Unknown;
    }
}