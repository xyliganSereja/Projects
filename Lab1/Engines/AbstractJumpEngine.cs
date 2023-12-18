namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public abstract class AbstractJumpEngine : IEngine
{
    private readonly double _firstFuel;
    private double _fuel;

    protected AbstractJumpEngine(double fuel)
    {
        _fuel = fuel;
        _firstFuel = fuel;
    }

    public double CountTime()
    {
        return _firstFuel - _fuel;
    }

    public bool TryMove(double distance)
    {
        double cost = CountMovement(distance);
        if (_fuel >= cost && _fuel >= 0)
        {
            _fuel -= cost;
            return true;
        }

        return false;
    }

    public abstract double CountMovement(double distance);
}