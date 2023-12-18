namespace Itmo.ObjectOrientedProgramming.Lab1.Engines;

public class AlphaEngine : AbstractJumpEngine
{
    public AlphaEngine(double fuel)
        : base(fuel)
    {
    }

    public override double CountMovement(double distance)
    {
        return distance;
    }
}