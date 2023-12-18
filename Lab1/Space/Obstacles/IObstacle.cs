namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Obstacles;

public interface IObstacle
{
    public virtual bool IsAsteroid
    {
        get => false;
    }
}