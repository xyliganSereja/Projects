using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Hulls;
using Itmo.ObjectOrientedProgramming.Lab1.Space;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships;

public class Spaceship
{
    private readonly Hull? _hull;
    private readonly PulseEngine? _pulseEngine;
    private readonly AbstractJumpEngine? _jumpEngine;

    private Spaceship(Hull hull, AbstractJumpEngine? jumpEngine, PulseEngine pulseEngine)
    {
        _hull = hull;
        _jumpEngine = jumpEngine;
        _pulseEngine = pulseEngine;
    }

    public static Spaceship PleasureShuttle(double activePlasma)
    {
        return new Spaceship(Hull.FirstClassHull(null), null, PulseEngine.ConstSpeed(activePlasma));
    }

    public static Spaceship Vaklas(double activePlasma, double gravitationalMatter, bool isPhoton)
    {
        return new Spaceship(Hull.SecondClassHull(Deflector.FirstClassDeflector(isPhoton, false)), new GammaEngine(gravitationalMatter), PulseEngine.ExpSpeed(activePlasma));
    }

    public static Spaceship Meridian(double activePlasma, bool isPhoton)
    {
        return new Spaceship(Hull.SecondClassHull(Deflector.SecondClassDeflector(isPhoton, true)), null, PulseEngine.ExpSpeed(activePlasma));
    }

    public static Spaceship Stella(double activePlasma, double gravitationalMatter, bool isPhoton)
    {
        return new Spaceship(Hull.FirstClassHull(Deflector.FirstClassDeflector(isPhoton, false)), new OmegaEngine(gravitationalMatter), PulseEngine.ConstSpeed(activePlasma));
    }

    public static Spaceship Avgur(double activePlasma, double gravitationalMatter, bool isPhoton)
    {
        return new Spaceship(Hull.ThirdClassHull(Deflector.ThirdClassDeflector(isPhoton)), new AlphaEngine(gravitationalMatter), PulseEngine.ExpSpeed(activePlasma));
    }

    public bool TryToDeflect(SpaceObstacle? obstacle)
    {
        if (obstacle is null || _hull is null)
        {
            throw new ObstaclesException("Unsupported obstacle type");
        }

        if (_hull.Deflector is null || !_hull.Deflector.TryDeflect(obstacle))
        {
            return _hull.TakeDamage(obstacle);
        }

        return true;
    }

    public bool TryToDeflect(FogObstacle? obstacle)
    {
        if (obstacle is null || _hull is null)
        {
            throw new ObstaclesException("Unsupported obstacle type");
        }

        if (_hull.Deflector is null || !_hull.Deflector.TryDeflect(obstacle))
        {
            return _hull.TakeDamage(obstacle);
        }

        return true;
    }

    public bool TryToDeflect(CosmoWhale? obstacle)
    {
        if (obstacle is null || _hull is null)
        {
            throw new ObstaclesException("Unsupported obstacle type");
        }

        if (_hull.Deflector is null || !_hull.Deflector.TryDeflect(obstacle))
        {
            return _hull.TakeDamage(obstacle);
        }

        return true;
    }

    public bool TryToFly(DefaultSpace? spaceObject)
    {
        if (spaceObject is null || _pulseEngine is null)
        {
            throw new SpaceException("Unsupported space type");
        }

        return _pulseEngine.TryMove(spaceObject.Length);
    }

    public bool TryToJump(FogSpace? spaceObject)
    {
        if (spaceObject is null)
        {
            throw new SpaceException("Unsupported space type");
        }

        if (_jumpEngine is null)
        {
            return false;
        }

        return _jumpEngine.TryMove(spaceObject.Length);
    }

    public bool TryToFlyInNitrine(NitrineSpace? spaceObject)
    {
        if (spaceObject is null || _pulseEngine is null || _hull is null)
        {
            throw new SpaceException("Unsupported space type");
        }

        return !_pulseEngine.IsConstBoost() && _pulseEngine.TryMove(spaceObject.Length);
    }

    public double TravelTime()
    {
        if (_pulseEngine is null)
        {
            throw new ShipException("ship has null reference");
        }

        double time = _pulseEngine.CountTime();
        if (_jumpEngine is not null)
        {
            time += _jumpEngine.CountTime();
        }

        return time;
    }

    public double FuelConsumed()
    {
        return TravelTime();
    }
}