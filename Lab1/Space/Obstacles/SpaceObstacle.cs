namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacles;

public class SpaceObstacle : IObstacle
{
    private SpaceObstacle(bool asteroid)
    {
        IsAsteroid = asteroid;
    }

    public bool IsAsteroid { get; }

    public static SpaceObstacle Asteroid()
    {
        return new SpaceObstacle(true);
    }

    public static SpaceObstacle Meteorite()
    {
        return new SpaceObstacle(false);
    }
}