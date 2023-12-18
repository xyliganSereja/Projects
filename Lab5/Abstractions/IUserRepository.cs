using Models.Users;

namespace Abstractions;

public interface IUserRepository
{
    User? FindUserById(long id);
    void InsertUser(long id, long password);
    void AddMoney(long id, decimal amount);
    void RemoveMoney(long id, decimal amount);
}