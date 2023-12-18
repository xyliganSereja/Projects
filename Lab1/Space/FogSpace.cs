using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space;

public class FogSpace : AbstractSpace
{
    private readonly LinkedList<FogObstacle> _fogObstacles;
    public FogSpace(double length, params FogObstacle[] obstacles)
        : base(length)
    {
        _fogObstacles = new LinkedList<FogObstacle>(obstacles);
    }

    public FogSpace(double length)
        : base(length)
    {
        _fogObstacles = new LinkedList<FogObstacle>();
    }

    public bool HaveObstacles()
    {
        return _fogObstacles.Count > 0;
    }

    public FogObstacle Next()
    {
        FogObstacle obstacle = _fogObstacles.First();
        _fogObstacles.RemoveFirst();
        return obstacle;
    }

    public override bool IsFogSpace()
    {
        return true;
    }
}