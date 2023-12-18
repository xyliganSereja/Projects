using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.FormFactor;
using Itmo.ObjectOrientedProgramming.Lab2.Memory;

namespace Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

public class Motherboard : IMotherboard<Motherboard>
{
    public Motherboard(string socket, string pciVersion, int sataNumber, Chipset chipset, int ddrType, int ramNumber, FormFactors formFactor, Bios.Bios bios)
    {
        Socket = socket;
        PciVersion = pciVersion;
        SataCollection = new List<IMemory>(sataNumber);
        SataNumber = 0;
        Chipset = chipset;
        DdrType = ddrType;
        RamCollection = new List<Ram.Ram>(ramNumber);
        RamNumber = 0;
        FormFactor = formFactor;
        Bios = bios;
        HasMemory = false;
        HasRam = false;
    }

    public string Socket { get; }
    public string PciVersion { get; }
    public IList<IMemory> SataCollection { get; }
    public Chipset Chipset { get; }
    public int DdrType { get; }
    public IList<Ram.Ram> RamCollection { get; }
    public FormFactors FormFactor { get; }
    public Bios.Bios Bios { get; }

    public bool HasMemory { get; private set; }

    public bool HasRam { get; private set; }
    private int SataNumber { get; set; }
    private int RamNumber { get; set; }

    public bool AddMemory(IMemory memory)
    {
        if (SataNumber == SataCollection.Count)
        {
            return false;
        }

        SataCollection[SataNumber++] = memory;
        HasMemory = true;
        return true;
    }

    public bool AddRam(Ram.Ram ram)
    {
        if (RamNumber == RamCollection.Count)
        {
            return false;
        }

        RamCollection[RamNumber++] = ram;
        HasRam = true;
        return true;
    }

    public bool IsCompatibleWithCpu(Cpu.Cpu? cpu)
    {
        if (cpu is null)
        {
            throw new CpuException("Cpu is null");
        }

        return cpu.Socket == Socket;
    }

    public int MemoryPowerConsumption()
    {
        int count = 0;
        for (int i = 0; i < SataNumber; i++)
        {
            count += SataCollection[i].PowerConsumption;
        }

        return count;
    }

    public int RamPowerConsumption()
    {
        int count = 0;
        for (int i = 0; i < RamNumber; i++)
        {
            count += RamCollection[i].PowerConsumption;
        }

        return count;
    }

    public bool IsCompatibleWithRam()
    {
        for (int i = 0; i < RamNumber; i++)
        {
            if (DdrType != RamCollection[i].DdrType)
            {
                return false;
            }
        }

        return true;
    }

    public bool IsCompatibleWithCooler(CoolingSystem.CoolingSystem coolingSystem)
    {
        if (coolingSystem is null)
        {
            throw new CoolingSystemException("Cooling system is null");
        }

        return coolingSystem.FormFactor == FormFactor;
    }

    public bool IsCompatibleWithVideoCard(VideoCard.VideoCard videoCard)
    {
        if (videoCard is null)
        {
            throw new VideoCardException("Video card is null");
        }

        return PciVersion == videoCard.PciVersion;
    }

    public Motherboard Clone()
    {
        return new Motherboard(Socket, PciVersion, SataCollection.Count, Chipset, DdrType, RamCollection.Count, FormFactor, Bios);
    }
}