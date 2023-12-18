namespace Itmo.ObjectOrientedProgramming.Lab2.Wifi;

public class WifiAdapter : IWifiAdapter<WifiAdapter>
{
    public WifiAdapter(string wifiStandard, string pciVersion, bool haveBluetooth, int powerConsumption)
    {
        WifiStandard = wifiStandard;
        PciVersion = pciVersion;
        HaveBluetooth = haveBluetooth;
        PowerConsumption = powerConsumption;
    }

    public string WifiStandard { get; }
    public string PciVersion { get; }
    public bool HaveBluetooth { get; }
    public int PowerConsumption { get; }

    public WifiAdapter Clone()
    {
        return new WifiAdapter(WifiStandard, PciVersion, HaveBluetooth, PowerConsumption);
    }
}