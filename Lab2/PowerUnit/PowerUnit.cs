using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.PowerUnit;

public class PowerUnit : IPowerUnit<PowerUnit>
{
    public PowerUnit(int power)
    {
        if (!IsValid(power))
        {
            throw new PowerUnitException("Power below zero");
        }

        Power = power;
    }

    public int Power { get; }
    public bool IsValid(int power)
    {
        return power > 0;
    }

    public PowerUnit Clone()
    {
        return new PowerUnit(Power);
    }
}