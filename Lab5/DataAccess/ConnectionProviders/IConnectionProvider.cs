using Npgsql;

namespace DataAccess.ConnectionProviders;

public interface IConnectionProvider
{
    NpgsqlConnection Connect();
}