using Npgsql;

namespace DataAccess.ConnectionProviders;

public class ConnectionProvider : IConnectionProvider
{
    public NpgsqlConnection Connect()
    {
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=vfntvfnbrf;Database=postgres";
        var connection = new NpgsqlConnection(connectionString);
        connection.Open();

        return connection;
    }
}