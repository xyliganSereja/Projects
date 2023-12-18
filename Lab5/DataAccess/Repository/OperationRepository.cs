using Abstractions;
using DataAccess.ConnectionProviders;
using Models.Exceptions;
using Models.Operations;
using Npgsql;

namespace DataAccess.Repository;

public class OperationRepository : IOperationRepository
{
    private readonly IConnectionProvider _connectionProvider;

    public OperationRepository(IConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public IEnumerable<Operation> GetOperationsByUserId(long userId)
    {
        const string sql = """
                           select *
                           from OperationHistory
                           where AccountId = @userId;
                           """;

        NpgsqlConnection connectionProvider = _connectionProvider.Connect();
        using var command = new NpgsqlCommand(sql, connectionProvider);
        command.Parameters.AddWithValue("@userId", userId);

        using NpgsqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (Enum.TryParse(reader.GetString(2), out OperationType type))
            {
                yield return new Operation(
                    accountId: reader.GetInt64(1),
                    operationType: type,
                    amount: reader.GetDecimal(3));
            }
            else
            {
                throw new OperationTypeException();
            }
        }
    }
}