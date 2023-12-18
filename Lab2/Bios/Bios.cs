using System.Collections.Generic;
using System.Globalization;

namespace Itmo.ObjectOrientedProgramming.Lab2.Bios;

public class Bios : IBios<Bios>
{
    public Bios(int biosType, int biosVersion)
    {
        BiosType = biosType;
        BiosVersion = biosVersion;
        CpuCollection = new HashSet<string>();
    }

    private int BiosType { get; }
    private int BiosVersion { get; }
    private HashSet<string> CpuCollection { get; }

    public bool ContainsCpu(string? name)
    {
        if (name is null)
        {
            return false;
        }

        return CpuCollection.Contains(name.ToLower(CultureInfo.CurrentCulture));
    }

    public bool AddCpu(string? name)
    {
        if (name is null || !ContainsCpu(name))
        {
            return false;
        }

        CpuCollection.Add(name);
        return true;
    }

    public Bios Clone()
    {
        return new Bios(BiosType, BiosVersion);
    }

    public bool Equals(Bios? bios)
    {
        if (bios is null)
        {
            return false;
        }

        return BiosType == bios.BiosType && BiosVersion == bios.BiosVersion;
    }
}