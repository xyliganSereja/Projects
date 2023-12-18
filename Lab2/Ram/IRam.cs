namespace Itmo.ObjectOrientedProgramming.Lab2.Ram;

public interface IRam<out T>
{
    public bool IsCompatibleWithXmp(Xmp.Xmp xmp);
    public bool IsValid();
    public T Clone();
}