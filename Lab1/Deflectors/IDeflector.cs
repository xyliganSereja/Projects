using Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflectors;

public interface IDeflector
{
    bool TryDeflect(IObstacle obstacle);
}