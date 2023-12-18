using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Memory;

public class Hdd : IMemory
{
    public Hdd(int hddVolume, int hddSpeed, int powerConsumption)
    {
        HddVolume = hddVolume;
        HddSpeed = hddSpeed;
        PowerConsumption = powerConsumption;
        if (!IsValid())
        {
            throw new MemoryException("Hdd volume or speed is below zero");
        }
    }

    public int HddVolume { get; }
    public int HddSpeed { get; }
    public int PowerConsumption { get; }
    public bool IsValid()
    {
        return HddVolume > 0 && HddSpeed > 0 && PowerConsumption > 0;
    }

    public IMemory Clone()
    {
        return new Hdd(HddVolume, HddSpeed, PowerConsumption);
    }
}