using Models.Operations;

namespace Abstractions;

public interface IOperationRepository
{
    IEnumerable<Operation> GetOperationsByUserId(long userId);
}