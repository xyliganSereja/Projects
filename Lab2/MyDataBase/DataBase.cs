using System;
using System.Collections.Generic;
using System.Threading;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.FormFactor;
using Itmo.ObjectOrientedProgramming.Lab2.Memory;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.Wifi;

namespace Itmo.ObjectOrientedProgramming.Lab2.MyDataBase;

public class DataBase
{
    private static readonly Lazy<DataBase> _dataBase;
#pragma warning disable CA1810
    static DataBase()
#pragma warning restore CA1810
    {
        _dataBase = new Lazy<DataBase>(() => new DataBase(), LazyThreadSafetyMode.ExecutionAndPublication);
    }

    private DataBase()
    {
        MotherboardsCollection = new Dictionary<string, Motherboard.Motherboard>();
        CpuCollection = new Dictionary<string, Cpu.Cpu>();
        BiosCollection = new Dictionary<string, Bios.Bios>();
        CoolingSystemCollection = new Dictionary<string, CoolingSystem.CoolingSystem>();
        RamsCollection = new Dictionary<string, Ram.Ram>();
        XmpCollection = new Dictionary<string, Xmp.Xmp>();
        VideoCardCollection = new Dictionary<string, VideoCard.VideoCard>();
        SsdCollection = new Dictionary<string, Ssd>();
        HddCollection = new Dictionary<string, Hdd>();
        BoxCollection = new Dictionary<string, Box.Box>();
        WifiAdapterCollection = new Dictionary<string, WifiAdapter>();
        PowerUnitCollection = new Dictionary<string, PowerUnit.PowerUnit>();
    }

    public static DataBase Instance => _dataBase.Value;
    private Dictionary<string, Motherboard.Motherboard> MotherboardsCollection { get; }
    private Dictionary<string, Cpu.Cpu> CpuCollection { get; }
    private Dictionary<string, Bios.Bios> BiosCollection { get; }
    private Dictionary<string, CoolingSystem.CoolingSystem> CoolingSystemCollection { get; }
    private Dictionary<string, Ram.Ram> RamsCollection { get; }
    private Dictionary<string, Xmp.Xmp> XmpCollection { get; }
    private Dictionary<string, VideoCard.VideoCard> VideoCardCollection { get; }
    private Dictionary<string, Ssd> SsdCollection { get; }
    private Dictionary<string, Hdd> HddCollection { get; }
    private Dictionary<string, Box.Box> BoxCollection { get; }
    private Dictionary<string, WifiAdapter> WifiAdapterCollection { get; }
    private Dictionary<string, PowerUnit.PowerUnit> PowerUnitCollection { get; }

    public void FillDataBase()
    {
        FillMother();
        FillCpu();
        FillRam();
        FillSsd();
        FillCoolerSystem();
        FillXmp();
        FillPowerUnit();
        FillWifiAdapter();
        FillBox();
    }

    public bool ContainsMotherBoard(string? name)
    {
        return name is not null && MotherboardsCollection.ContainsKey(name);
    }

    public bool InsertMotherboard(string? name, Motherboard.Motherboard motherboard)
    {
        if (name is null)
        {
            throw new MotherBoardException("Motherboard name can't ne null");
        }

        if (MotherboardsCollection.ContainsKey(name))
        {
            return false;
        }

        MotherboardsCollection[name] = motherboard;
        return true;
    }

    public Motherboard.Motherboard BuildMotherboard(string? name)
    {
        if (name is null)
        {
            throw new MotherBoardException("Motherboard name is null");
        }

        return MotherboardsCollection[name].Clone();
    }

    public bool ContainsCpu(string? name)
    {
        return name is not null && CpuCollection.ContainsKey(name);
    }

    public bool InsertCpu(string? name, Cpu.Cpu cpu)
    {
        if (name is null)
        {
            throw new CpuException("Cpu name can't be null");
        }

        if (CpuCollection.ContainsKey(name))
        {
            return false;
        }

        CpuCollection[name] = cpu;
        return true;
    }

    public Cpu.Cpu BuildCpu(string? name)
    {
        if (name is null)
        {
            throw new CpuException("Cpu name is null");
        }

        return CpuCollection[name].Clone();
    }

    public bool ContainsBios(string? name)
    {
        return name is not null && BiosCollection.ContainsKey(name);
    }

    public bool InsertBios(string? name, Bios.Bios bios)
    {
        if (name is null)
        {
            throw new BiosException("Bios name can't be null");
        }

        if (BiosCollection.ContainsKey(name))
        {
            return false;
        }

        BiosCollection[name] = bios;
        return true;
    }

    public Bios.Bios BuildBios(string? name)
    {
        if (name is null)
        {
            throw new BiosException("Bios name is null");
        }

        return BiosCollection[name].Clone();
    }

    public bool ContainsCooler(string? name)
    {
        return name is not null && CoolingSystemCollection.ContainsKey(name);
    }

    public bool InsertCooler(string? name, CoolingSystem.CoolingSystem coolingSystem)
    {
        if (name is null)
        {
            throw new CoolingSystemException("Cooling system name can't be null");
        }

        if (CoolingSystemCollection.ContainsKey(name))
        {
            return false;
        }

        CoolingSystemCollection[name] = coolingSystem;
        return true;
    }

    public CoolingSystem.CoolingSystem BuildCoolingSystem(string? name)
    {
        if (name is null)
        {
            throw new CoolingSystemException("Cooling system name is null");
        }

        return CoolingSystemCollection[name].Clone();
    }

    public bool ContainsRam(string? name)
    {
        return name is not null && RamsCollection.ContainsKey(name);
    }

    public bool InsertRam(string? name, Ram.Ram ram)
    {
        if (name is null)
        {
            throw new RamException("Ram name can't be null");
        }

        if (RamsCollection.ContainsKey(name))
        {
            return false;
        }

        RamsCollection[name] = ram;
        return true;
    }

    public Ram.Ram BuildRam(string? name)
    {
        if (name is null)
        {
            throw new RamException("Ram name is null");
        }

        return RamsCollection[name].Clone();
    }

    public bool ContainsXmp(string? name)
    {
        return name is not null && XmpCollection.ContainsKey(name);
    }

    public bool InsertXmp(string? name, Xmp.Xmp xmp)
    {
        if (name is null)
        {
            throw new XmpException("Xmp name can't be null");
        }

        if (XmpCollection.ContainsKey(name))
        {
            return false;
        }

        XmpCollection[name] = xmp;
        return true;
    }

    public Xmp.Xmp BuildXmp(string? name)
    {
        if (name is null)
        {
            throw new XmpException("Motherboard name is null");
        }

        return XmpCollection[name].Clone();
    }

    public bool ContainsVideoCard(string? name)
    {
        return name is not null && VideoCardCollection.ContainsKey(name);
    }

    public bool InsertVideoCard(string? name, VideoCard.VideoCard videoCard)
    {
        if (name is null)
        {
            throw new VideoCardException("Video Card name can't be null");
        }

        if (VideoCardCollection.ContainsKey(name))
        {
            return false;
        }

        VideoCardCollection[name] = videoCard;
        return true;
    }

    public VideoCard.VideoCard BuildVideoCard(string? name)
    {
        if (name is null)
        {
            throw new VideoCardException("Video card name is null");
        }

        return VideoCardCollection[name].Clone();
    }

    public bool ContainsSsd(string? name)
    {
        return name is not null && SsdCollection.ContainsKey(name);
    }

    public bool InsertSsd(string? name, Ssd ssd)
    {
        if (name is null)
        {
            throw new MemoryException("Ssd name can't be null");
        }

        if (SsdCollection.ContainsKey(name))
        {
            return false;
        }

        SsdCollection[name] = ssd;
        return true;
    }

    public Ssd BuildSsd(string? name)
    {
        if (name is null)
        {
            throw new MemoryException("Ssd name is null");
        }

        return (Ssd)SsdCollection[name].Clone();
    }

    public bool ContainsHdd(string? name)
    {
        return name is not null && HddCollection.ContainsKey(name);
    }

    public bool InsertHdd(string? name, Hdd hdd)
    {
        if (name is null)
        {
            throw new MemoryException("Hdd name can't be null");
        }

        if (HddCollection.ContainsKey(name))
        {
            return false;
        }

        HddCollection[name] = hdd;
        return true;
    }

    public Hdd BuildHdd(string? name)
    {
        if (name is null)
        {
            throw new MemoryException("Hdd name is null");
        }

        return (Hdd)HddCollection[name].Clone();
    }

    public bool ContainsBox(string? name)
    {
        return name is not null && BoxCollection.ContainsKey(name);
    }

    public bool InsertBox(string? name, Box.Box box)
    {
        if (name is null)
        {
            throw new BoxException("Box name can't be null");
        }

        if (BoxCollection.ContainsKey(name))
        {
            return false;
        }

        BoxCollection[name] = box;
        return true;
    }

    public Box.Box BuildBox(string? name)
    {
        if (name is null)
        {
            throw new BoxException("Box name is null");
        }

        return BoxCollection[name].Clone();
    }

    public bool ContainsWifiAdapter(string? name)
    {
        return name is not null && WifiAdapterCollection.ContainsKey(name);
    }

    public bool InsertWifiAdapter(string? name, WifiAdapter wifiAdapter)
    {
        if (name is null)
        {
            throw new WifiAdapterException("Wifi adapter name can't be null");
        }

        if (WifiAdapterCollection.ContainsKey(name))
        {
            return false;
        }

        WifiAdapterCollection[name] = wifiAdapter;
        return true;
    }

    public WifiAdapter BuildWifiAdapter(string? name)
    {
        if (name is null)
        {
            throw new WifiAdapterException("Ssd name is null");
        }

        return WifiAdapterCollection[name];
    }

    public bool ContainsPowerUnit(string? name)
    {
        return name is not null && PowerUnitCollection.ContainsKey(name);
    }

    public bool InsertPowerUnit(string? name, PowerUnit.PowerUnit powerUnit)
    {
        if (name is null)
        {
            throw new PowerUnitException("PowerUnit name can't be null");
        }

        if (PowerUnitCollection.ContainsKey(name))
        {
            return false;
        }

        PowerUnitCollection[name] = powerUnit;
        return true;
    }

    public PowerUnit.PowerUnit BuildPowerUnit(string? name)
    {
        if (name is null)
        {
            throw new PowerUnitException("PowerUnit name is null");
        }

        return PowerUnitCollection[name].Clone();
    }

    private void FillMother()
    {
        InsertMotherboard("Mother_v1", new Motherboard.Motherboard("lgt_1200", "v1", 4, new Chipset(4, 4), 4, 4, FormFactors.Low, new Bios.Bios(1, 1)));
    }

    private void FillCpu()
    {
        InsertCpu("Cpu_v1", new Cpu.Cpu("lgt_1200", 100, 2, true, 100, 100, 100));
        InsertCpu("Cpu_v2", new Cpu.Cpu("lgt_1200", 100, 2, true, 100, 100, 1000));
    }

    private void FillRam()
    {
        InsertRam("Ram_1", new Ram.Ram(100, 100, 100, 4, 1, FormFactors.Low));
    }

    private void FillSsd()
    {
        InsertSsd("Ssd_v1", new Ssd(100, 100, 1));
    }

    private void FillCoolerSystem()
    {
        InsertCooler("Cooler_v1", new CoolingSystem.CoolingSystem(FormFactors.Low, 100));
        InsertCooler("Cooler_v2", new CoolingSystem.CoolingSystem(FormFactors.Low, 1));
    }

    private void FillXmp()
    {
        InsertXmp("Xmp_v1", new Xmp.Xmp(100, 100, 100));
    }

    private void FillPowerUnit()
    {
        InsertPowerUnit("PowerUnit_v1", new PowerUnit.PowerUnit(1000));
    }

    private void FillWifiAdapter()
    {
        InsertWifiAdapter("5G", new WifiAdapter("first", "v1", false, 1));
    }

    private void FillBox()
    {
        InsertBox("Box_v1", Box.Box.SmallBox(1000, 1000));
    }
}