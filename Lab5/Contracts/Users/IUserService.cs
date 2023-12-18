namespace Contracts.Users;

public interface IUserService
{
    LoginResult Login(long id, long password);
    LoginResult LoginAdmin(string name, string password);
    void Logout();
}