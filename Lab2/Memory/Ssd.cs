using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Memory;

public class Ssd : IMemory
{
    public Ssd(int ssdVolume, int ssdSpeed, int powerConsumption)
    {
        SsdVolume = ssdVolume;
        SsdSpeed = ssdSpeed;
        PowerConsumption = powerConsumption;
        if (!IsValid())
        {
            throw new MemoryException("Ssd volume or speed is below zero");
        }
    }

    public int SsdVolume { get; }
    public int SsdSpeed { get; }
    public int PowerConsumption { get; }
    public bool IsValid()
    {
        return SsdVolume > 0 && SsdSpeed > 0 && PowerConsumption > 0;
    }

    public IMemory Clone()
    {
        return new Ssd(SsdVolume, SsdSpeed, PowerConsumption);
    }
}