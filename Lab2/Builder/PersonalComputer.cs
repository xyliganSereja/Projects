using Itmo.ObjectOrientedProgramming.Lab2.MyDataBase;
using Itmo.ObjectOrientedProgramming.Lab2.Wifi;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builder;

public class PersonalComputer
{
    public PersonalComputer()
    {
        DataBase = DataBase.Instance;
        DataBase.FillDataBase();
    }

    public Motherboard.Motherboard? Motherboard { get; private set; }
    public Cpu.Cpu? Cpu { get; private set; }
    public CoolingSystem.CoolingSystem? CoolingSystem { get; private set; }
    public Xmp.Xmp? Xmp { get; private set; }
    public VideoCard.VideoCard? VideoCard { get; private set; }
    public Box.Box? Box { get; private set; }
    public WifiAdapter? WifiAdapter { get; private set; }
    public PowerUnit.PowerUnit? PowerUnit { get; private set; }
    private DataBase DataBase { get; }

    public void AddMother(string name)
    {
        if (DataBase.ContainsMotherBoard(name))
        {
            Motherboard = DataBase.BuildMotherboard(name);
        }
    }

    public void AddCpu(string name)
    {
        if (DataBase.ContainsCpu(name))
        {
            Cpu = DataBase.BuildCpu(name);
        }
    }

    public void AddCoolerSystem(string name)
    {
        if (DataBase.ContainsCooler(name))
        {
            CoolingSystem = DataBase.BuildCoolingSystem(name);
        }
    }

    public void AddRam(string name)
    {
        if (DataBase.ContainsRam(name) && Motherboard is not null)
        {
            Motherboard.AddRam(DataBase.BuildRam(name));
        }
    }

    public void AddXmp(string name)
    {
        if (DataBase.ContainsXmp(name))
        {
            Xmp = DataBase.BuildXmp(name);
        }
    }

    public void AddVideoCard(string name)
    {
        if (DataBase.ContainsVideoCard(name))
        {
            VideoCard = DataBase.BuildVideoCard(name);
        }
    }

    public void AddSsd(string name)
    {
        if (DataBase.ContainsSsd(name) && Motherboard is not null)
        {
            Motherboard.AddMemory(DataBase.BuildSsd(name));
        }
    }

    public void AddHdd(string name)
    {
        if (DataBase.ContainsHdd(name) && Motherboard is not null)
        {
            Motherboard.AddMemory(DataBase.BuildHdd(name));
        }
    }

    public void AddBox(string name)
    {
        if (DataBase.ContainsBox(name))
        {
            Box = DataBase.BuildBox(name);
        }
    }

    public void AddPowerUnit(string name)
    {
        if (DataBase.ContainsPowerUnit(name))
        {
            PowerUnit = DataBase.BuildPowerUnit(name);
        }
    }

    public void AddWifiAdapter(string name)
    {
        if (DataBase.ContainsWifiAdapter(name))
        {
            WifiAdapter = DataBase.BuildWifiAdapter(name);
        }
    }

    public BuildResult Build()
    {
        return BuildValidator.ValidateBuild(this);
    }
}