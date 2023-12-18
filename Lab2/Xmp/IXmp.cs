namespace Itmo.ObjectOrientedProgramming.Lab2.Xmp;

public interface IXmp<out T>
{
    public T Clone();
}