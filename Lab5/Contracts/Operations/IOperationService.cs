using Models.Operations;

namespace Contracts.Operations;

public interface IOperationService
{
    IEnumerable<Operation> GetOperationsByUserId(long userId);
}