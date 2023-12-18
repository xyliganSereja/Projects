namespace Itmo.ObjectOrientedProgramming.Lab2.Wifi;

public interface IWifiAdapter<out T>
{
    public T Clone();
}