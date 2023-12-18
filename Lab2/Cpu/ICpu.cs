namespace Itmo.ObjectOrientedProgramming.Lab2.Cpu;

public interface ICpu<out T>
{
    public bool IsCompatibleWithCooler(CoolingSystem.CoolingSystem coolingSystem);
    public bool IsValid();
    public T Clone();
}