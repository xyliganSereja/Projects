using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public class Deflector : IDeflector
{
    private readonly double _asteroidDamage;
    private readonly double _meteoriteDamage;
    private readonly double _cosmoWhalesDamage;
    private readonly double _antimatterFlaresDamage;
    private readonly bool _haveAntinitrineEmitter;
    private double _deflectorHealth;
    private double _photonDeflectorHeath;

    private Deflector(double asteroidDamage, double meteoriteDamage, bool isPhoton, bool haveAntinitrineEmitter)
    {
        _asteroidDamage = asteroidDamage;
        _meteoriteDamage = meteoriteDamage;
        if (isPhoton)
        {
            _antimatterFlaresDamage = 33;
            _photonDeflectorHeath = 99;
        }
        else
        {
            _photonDeflectorHeath = 0;
            _antimatterFlaresDamage = 100;
        }

        _cosmoWhalesDamage = haveAntinitrineEmitter ? 100 : 101;
        _haveAntinitrineEmitter = haveAntinitrineEmitter;
        _deflectorHealth = 100;
    }

    public static Deflector FirstClassDeflector(bool isPhoton, bool haveAntinitrineEmitter)
    {
        return new Deflector(50, 100, isPhoton, haveAntinitrineEmitter);
    }

    public static Deflector SecondClassDeflector(bool isPhoton, bool haveAntinitrineEmitter)
    {
        return new Deflector(10, 33, isPhoton, haveAntinitrineEmitter);
    }

    public static Deflector ThirdClassDeflector(bool isPhoton)
    {
        return new Deflector(2.5, 10, isPhoton, true);
    }

    public bool TryDeflect(IObstacle? obstacle)
    {
        if (obstacle is null)
        {
            throw new ObstaclesException("Unsupported type of obstacle");
        }

        switch (obstacle)
        {
            case SpaceObstacle:
            {
                if (IsWork() && obstacle.IsAsteroid && _deflectorHealth - _asteroidDamage >= 0)
                {
                    _deflectorHealth -= _asteroidDamage;
                    return true;
                }

                if (IsWork() && !obstacle.IsAsteroid && _deflectorHealth - _meteoriteDamage >= 0)
                {
                    _deflectorHealth -= _meteoriteDamage;
                    return true;
                }

                _deflectorHealth = 0;
                return false;
            }

            case FogObstacle:
            {
                if (IsWorkPhoton() && _photonDeflectorHeath - _antimatterFlaresDamage >= 0)
                {
                    _photonDeflectorHeath -= _antimatterFlaresDamage;
                    return true;
                }

                _photonDeflectorHeath = 0;
                return false;
            }

            case CosmoWhale:
            {
                if (!_haveAntinitrineEmitter && _deflectorHealth - _cosmoWhalesDamage >= 0)
                {
                    _deflectorHealth = 0;
                    return true;
                }

                if (_haveAntinitrineEmitter)
                {
                    return true;
                }

                _deflectorHealth = 0;
                return false;
            }

            default: throw new ObstaclesException("Unsupported obstacle type");
        }
    }

    private bool IsWorkPhoton()
    {
        return _photonDeflectorHeath >= 0;
    }

    private bool IsWork()
    {
        return _deflectorHealth >= 0;
    }
}