namespace Itmo.ObjectOrientedProgramming.Lab2.Xmp;

public class Xmp : IXmp<Xmp>
{
    public Xmp(int timings, int voltage, int frequency)
    {
        Timings = timings;
        Voltage = voltage;
        Frequency = frequency;
    }

    public int Timings { get; }
    public int Voltage { get; }
    public int Frequency { get; }

    public Xmp Clone()
    {
        return new Xmp(Timings, Voltage, Frequency);
    }
}