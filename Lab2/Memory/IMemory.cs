namespace Itmo.ObjectOrientedProgramming.Lab2.Memory;

public interface IMemory
{
    int PowerConsumption { get; }
    public bool IsValid();
    public IMemory Clone();
}