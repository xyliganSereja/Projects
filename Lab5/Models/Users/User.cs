namespace Models.Users;

public class User
{
    public User(long id, long password, decimal balance)
    {
        Id = id;
        Password = password;
        Balance = balance;
    }

    public long Id { get; }
    public long Password { get; }
    public decimal Balance { get; }
}