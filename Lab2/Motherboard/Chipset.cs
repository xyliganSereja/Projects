namespace Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

public class Chipset
{
    public Chipset(int pciNumber, int sataNumber)
    {
        PciNumber = pciNumber;
        SataNumber = sataNumber;
    }

    public int PciNumber { get; }
    public int SataNumber { get; }
}