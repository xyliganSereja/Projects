using Itmo.ObjectOrientedProgramming.Lab1.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Hulls;

public class Hull
{
    private readonly double _asteroidDamage;
    private readonly double _meteoriteDamage;
    private double _spaceshipHealthPoints;

    private Hull(double asteroidDamage, double meteoriteDamage, IDeflector? deflector)
    {
        _asteroidDamage = asteroidDamage;
        _meteoriteDamage = meteoriteDamage;
        _spaceshipHealthPoints = 101;
        Deflector = deflector;
    }

    public IDeflector? Deflector { get; }

    public static Hull FirstClassHull(IDeflector? deflector)
    {
        return new Hull(100, 101, deflector);
    }

    public static Hull SecondClassHull(IDeflector? deflector)
    {
        return new Hull(10, 33, deflector);
    }

    public static Hull ThirdClassHull(IDeflector? deflector)
    {
        return new Hull(5, 20, deflector);
    }

    public bool TakeDamage(SpaceObstacle? obstacle)
    {
        if (obstacle is null)
        {
            throw new ObstaclesException("Obstacle is null");
        }

        if (obstacle.IsAsteroid && (Deflector is null || !Deflector.TryDeflect(obstacle)))
        {
            _spaceshipHealthPoints -= _asteroidDamage;
        }
        else if (Deflector is null || !Deflector.TryDeflect(obstacle))
        {
            _spaceshipHealthPoints -= _meteoriteDamage;
        }

        return IsAlive();
    }

    public bool TakeDamage(FogObstacle? obstacle)
    {
        if (obstacle is not null && (Deflector is null || !Deflector.TryDeflect(obstacle)))
        {
            return false;
        }

        throw new ObstaclesException("Obstacle is null");
    }

    public bool TakeDamage(CosmoWhale? obstacle)
    {
        if (obstacle is not null && (Deflector is null || !Deflector.TryDeflect(obstacle)))
        {
            _spaceshipHealthPoints -= 101;
            return false;
        }

        throw new ObstaclesException("Obstacle is null");
    }

    private bool IsAlive()
    {
        return _spaceshipHealthPoints >= 0;
    }
}