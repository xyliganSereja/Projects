namespace Itmo.ObjectOrientedProgramming.Lab1.Space;

public abstract class AbstractSpace
{
    protected AbstractSpace(double length)
    {
        Length = length;
    }

    public double Length { get; }

    public virtual bool IsDefaultSpace()
    {
        return false;
    }

    public virtual bool IsFogSpace()
    {
        return false;
    }

    public virtual bool IsNitrineSpace()
    {
        return false;
    }
}