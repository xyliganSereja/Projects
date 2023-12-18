namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacles;

public class CosmoWhale : IObstacle
{
    private CosmoWhale(bool antimatterFlares)
    {
        IsCosmoWhale = antimatterFlares;
    }

    public bool IsCosmoWhale { get; }

    public static CosmoWhale AntimatterFlares()
    {
        return new CosmoWhale(true);
    }
}