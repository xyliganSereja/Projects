namespace Models.Exceptions;

public class OperationTypeException : Exception
{
    public OperationTypeException()
        : base("Unsupported operation type")
    {
    }

    public OperationTypeException(string message)
        : base(message)
    {
    }

    public OperationTypeException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}