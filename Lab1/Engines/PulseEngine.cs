using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class PulseEngine : IEngine
{
    private readonly double _boost;
    private readonly double _firstFuel;
    private double _speed;
    private double _fuel;

    private PulseEngine(double boost, double fuel)
    {
        _speed = 100;
        _boost = boost;
        _fuel = fuel;
        _firstFuel = fuel;
    }

    public static PulseEngine ConstSpeed(double fuel)
    {
        return new PulseEngine(1, fuel);
    }

    public static PulseEngine ExpSpeed(double fuel)
    {
        return new PulseEngine(double.E, fuel);
    }

    public bool IsConstBoost()
    {
        return _boost < 2;
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

    public double CountMovement(double distance)
    {
        switch (_boost)
        {
            case 1:
            {
                return double.Max(1, distance / _speed);
            }

            case double.E:
            {
                double time = FindTime(distance);
                _speed += double.E * time;
                return time / (2 * double.E);
            }

            default:
            {
                throw new EngineException("unsupported type of engine");
            }
        }
    }

    private double FindTime(double distance)
    {
        return _speed + double.Sqrt((_speed * _speed) + (2 * double.E * distance));
    }
}