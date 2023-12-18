namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public interface IEngine
{
    public bool TryMove(double distance);
    public double CountMovement(double distance);

    public double CountTime();
}