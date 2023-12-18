using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.FormFactor;

namespace Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;

public class CoolingSystem : ICoolingSystem<CoolingSystem>
{
    public CoolingSystem(FormFactors formFactor, int maxTdp)
    {
        FormFactor = formFactor;
        MaxTdp = maxTdp;
        SocketCollection = new HashSet<string>();
    }

    private CoolingSystem(FormFactors formFactor, int maxTdp, HashSet<string> socketCollection)
    {
        FormFactor = formFactor;
        MaxTdp = maxTdp;
        SocketCollection = socketCollection;
    }

    public FormFactors FormFactor { get; }
    public int MaxTdp { get; }
    public HashSet<string> SocketCollection { get; }

    public CoolingSystem Clone()
    {
        return new CoolingSystem(FormFactor, MaxTdp, SocketCollection);
    }
}