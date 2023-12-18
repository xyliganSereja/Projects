using System.Text;

namespace Models.Operations;

public class Operation
{
    public Operation(long accountId, OperationType operationType, decimal amount)
    {
        AccountId = accountId;
        OperationType = operationType;
        Amount = amount;
    }

    public long AccountId { get; }
    public OperationType OperationType { get; }
    public decimal Amount { get; }
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append(AccountId).Append(' ').Append(OperationType).Append(Amount);
        return sb.ToString();
    }
}
