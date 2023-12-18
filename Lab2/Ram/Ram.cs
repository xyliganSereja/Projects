using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.FormFactor;

namespace Itmo.ObjectOrientedProgramming.Lab2.Ram;

public class Ram : IRam<Ram>
{
    public Ram(int memoryVolume, int voltage, int frequency, int ddrType, int powerConsumption, FormFactors formFactor)
    {
        MemoryVolume = memoryVolume;
        Voltage = voltage;
        Frequency = frequency;
        DdrType = ddrType;
        PowerConsumption = powerConsumption;
        FormFactor = formFactor;
        if (!IsValid())
        {
            throw new RamException("Some RAM attributes is below zero");
        }
    }

    public int MemoryVolume { get; }
    public int Voltage { get; }
    public int Frequency { get; }
    public int DdrType { get; }
    public int PowerConsumption { get; }
    public FormFactors FormFactor { get; }

    public bool IsCompatibleWithXmp(Xmp.Xmp xmp)
    {
        if (xmp is null)
        {
            throw new XmpException("Xmp is null");
        }

        return Voltage == xmp.Voltage && Frequency == xmp.Frequency;
    }

    public bool IsValid()
    {
        return MemoryVolume > 0 && Voltage > 0 && Frequency > 0 && PowerConsumption > 0;
    }

    public Ram Clone()
    {
        return new Ram(MemoryVolume, Voltage, Frequency, DdrType, PowerConsumption, FormFactor);
    }
}