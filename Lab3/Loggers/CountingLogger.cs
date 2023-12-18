namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers;

public class CountingLogger : ILogger
{
    public int Count { get; private set; }
    public void Log()
    {
        Count++;
    }

    public string GetInfo()
    {
#pragma warning disable CA1305
        return Count.ToString();
#pragma warning restore CA1305
    }
}