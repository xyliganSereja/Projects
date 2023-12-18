namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class GammaEngine : AbstractJumpEngine
{
    public GammaEngine(double fuel)
        : base(fuel)
    {
    }

    public override double CountMovement(double distance)
    {
        return distance * distance;
    }
}