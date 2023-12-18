namespace Itmo.ObjectOrientedProgramming.Lab2.Bios;

public interface IBios<out T>
{
    public bool ContainsCpu(string? name);
    public bool AddCpu(string? name);
    public T Clone();
}