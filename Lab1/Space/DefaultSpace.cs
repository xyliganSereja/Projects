using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space;

public class DefaultSpace : AbstractSpace
{
    private readonly LinkedList<SpaceObstacle> _spaceObstacles;
    public DefaultSpace(double length, params SpaceObstacle[] spaceObstacles)
        : base(length)
    {
        _spaceObstacles = new LinkedList<SpaceObstacle>(spaceObstacles);
    }

    public DefaultSpace(double length)
        : base(length)
    {
        _spaceObstacles = new LinkedList<SpaceObstacle>();
    }

    public bool HaveObstacles()
    {
        return _spaceObstacles.Count > 0;
    }

    public SpaceObstacle Next()
    {
        SpaceObstacle obstacle = _spaceObstacles.First();
        _spaceObstacles.RemoveFirst();
        return obstacle;
    }

    public override bool IsDefaultSpace()
    {
        return true;
    }
}