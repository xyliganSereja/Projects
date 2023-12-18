namespace Itmo.ObjectOrientedProgramming.Lab2.PowerUnit;

public interface IPowerUnit<out T>
{
    public int Power { get; }
    public bool IsValid(int power);
    public T Clone();
}