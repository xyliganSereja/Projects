using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space;

public class NitrineSpace : AbstractSpace
{
    private LinkedList<CosmoWhale> _nitrineObstacle;
    public NitrineSpace(double length, params CosmoWhale[] nitrineObstacles)
        : base(length)
    {
        _nitrineObstacle = new LinkedList<CosmoWhale>(nitrineObstacles);
    }

    public NitrineSpace(double length)
        : base(length)
    {
        _nitrineObstacle = new LinkedList<CosmoWhale>();
    }

    public bool HaveObstacles()
    {
        return _nitrineObstacle.Count > 0;
    }

    public CosmoWhale Next()
    {
        CosmoWhale obstacle = _nitrineObstacle.First();
        _nitrineObstacle.RemoveFirst();
        return obstacle;
    }

    public override bool IsNitrineSpace()
    {
        return true;
    }
}