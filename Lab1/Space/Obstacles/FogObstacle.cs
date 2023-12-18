namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacles;

public class FogObstacle : IObstacle
{
    private FogObstacle(bool antimatterFlares)
    {
        IsAntimatterFlares = antimatterFlares;
    }

    public bool IsAntimatterFlares { get; }

    public static FogObstacle AntimatterFlares()
    {
        return new FogObstacle(true);
    }
}