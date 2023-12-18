using Abstractions;
using DataAccess.ConnectionProviders;
using Models.Users;
using Npgsql;

namespace DataAccess.Repository;

public class UserRepository : IUserRepository
{
    private readonly IConnectionProvider _connectionProvider;

    public UserRepository(IConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public User? FindUserById(long id)
    {
        const string sql = """
                           select *
                           from Accounts
                           where AccountId = @id;
                           """;

        NpgsqlConnection connectionProvider = _connectionProvider.Connect();
        using var command = new NpgsqlCommand(sql, connectionProvider);
        command.Parameters.AddWithValue("@id", id);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
        {
            return null;
        }

        return new User(
            id: reader.GetInt64(0),
            password: reader.GetInt64(1),
            balance: reader.GetInt64(2));
    }

    public void InsertUser(long id, long password)
    {
        const string sql = """
                           INSERT INTO Accounts
                           VALUES (@id, @password, 0)
                           """;

        NpgsqlConnection connectionProvider = _connectionProvider.Connect();
        using var command = new NpgsqlCommand(sql, connectionProvider);
        command.Parameters.AddWithValue("@id", id);
        command.Parameters.AddWithValue("@password", password);

        command.ExecuteNonQuery();
    }

    public void AddMoney(long id, decimal amount)
    {
        User? user = FindUserById(id);

        if (user is null)
        {
            return;
        }

        const string sql = """
                           UPDATE Accounts
                           SET AccountBalance = AccountBalance + @amount
                           WHERE AccountId = @id
                           """;

        NpgsqlConnection connectionProvider = _connectionProvider.Connect();
        using var command = new NpgsqlCommand(sql, connectionProvider);
        command.Parameters.AddWithValue("@amount", amount);
        command.Parameters.AddWithValue("@id", id);

        command.ExecuteNonQuery();
    }

    public void RemoveMoney(long id, decimal amount)
    {
        User? user = FindUserById(id);

        if (user is null)
        {
            return;
        }

        const string sql = """
                           UPDATE Accounts
                           SET AccountBalance = AccountBalance - @amount
                           WHERE AccountId = @id
                           """;

        NpgsqlConnection connectionProvider = _connectionProvider.Connect();
        using var command = new NpgsqlCommand(sql, connectionProvider);
        command.Parameters.AddWithValue("@amount", amount);
        command.Parameters.AddWithValue("@id", id);

        command.ExecuteNonQuery();
    }
}