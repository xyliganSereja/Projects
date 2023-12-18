using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Cpu;

public class Cpu : ICpu<Cpu>
{
    public Cpu(string socket, int coreFrequency, int coreNumber, bool hasVideoCore, int memoryFrequency, int heatGeneration, int powerConsumption)
    {
        Socket = socket;
        CoreFrequency = coreFrequency;
        CoreNumber = coreNumber;
        HasVideoCore = hasVideoCore;
        MemoryFrequency = memoryFrequency;
        HeatGeneration = heatGeneration;
        PowerConsumption = powerConsumption;
        if (!IsValid())
        {
            throw new CpuException("Some attributes value below zero");
        }
    }

    public string Socket { get; }
    public int CoreFrequency { get; }
    public int CoreNumber { get; }
    public bool HasVideoCore { get; }
    public int MemoryFrequency { get; }
    public int HeatGeneration { get; }
    public int PowerConsumption { get; }

    public bool IsCompatibleWithCooler(CoolingSystem.CoolingSystem coolingSystem)
    {
        if (coolingSystem is null)
        {
            throw new CoolingSystemException("Cooler is null");
        }

        return coolingSystem.MaxTdp >= HeatGeneration;
    }

    public bool IsValid()
    {
        return CoreFrequency > 0 && CoreNumber > 0 && MemoryFrequency > 0 && HeatGeneration > 0 && PowerConsumption > 0;
    }

    public Cpu Clone()
    {
        return new Cpu(Socket, CoreFrequency, CoreNumber, HasVideoCore, MemoryFrequency, HeatGeneration, PowerConsumption);
    }
}