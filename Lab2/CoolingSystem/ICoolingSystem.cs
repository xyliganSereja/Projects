namespace Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;

public interface ICoolingSystem<out T>
{
    public T Clone();
}