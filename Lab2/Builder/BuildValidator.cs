using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builder;

public static class BuildValidator
{
    public static BuildResult ValidateBuild(PersonalComputer? personalComputer)
    {
        if (personalComputer is null)
        {
            throw new ComputerException("Computer is null");
        }

        if (personalComputer.Motherboard is null)
        {
            return new BuildResult.Failure("You have no mother, build failed");
        }

        if (personalComputer.Cpu is null)
        {
            return new BuildResult.Failure("You have no cpu, build failed");
        }

        if (personalComputer.CoolingSystem is null)
        {
            return new BuildResult.Failure("You have no cooling system, build failed");
        }

        if (personalComputer.Xmp is null)
        {
            return new BuildResult.Failure("You have no xmp, build failed");
        }

        if (!personalComputer.Cpu.IsCompatibleWithCooler(personalComputer.CoolingSystem))
        {
            return new BuildResult.Failure("Cpu generate more heat than max TDP");
        }

        if (personalComputer.Box is null)
        {
            return new BuildResult.Failure("You have no box, build failed");
        }

        if (personalComputer.PowerUnit is null)
        {
            return new BuildResult.Failure("You have no PowerUnit, build failed");
        }

        if (!personalComputer.Cpu.HasVideoCore && personalComputer.VideoCard is null)
        {
            return new BuildResult.Failure("You have no video core, build failed");
        }

        if (!personalComputer.Motherboard.IsCompatibleWithCpu(personalComputer.Cpu))
        {
            return new BuildResult.Failure("Cpu and motherboard sockets are incompatible");
        }

        if (!personalComputer.Motherboard.IsCompatibleWithCooler(personalComputer.CoolingSystem))
        {
            return new BuildResult.Failure("Mother is not compatible with cooler");
        }

        if (!personalComputer.Motherboard.IsCompatibleWithRam())
        {
            return new BuildResult.Failure("Mother is not compatible with ram");
        }

        if (!personalComputer.Motherboard.RamCollection.All(ram => ram.IsCompatibleWithXmp(personalComputer.Xmp)))
        {
            return new BuildResult.Failure("Ram is not compatible with xmp");
        }

        int powerCount = 0;
        powerCount += personalComputer.Cpu.PowerConsumption;
        if (personalComputer.VideoCard is not null)
        {
            powerCount += personalComputer.VideoCard.PowerConsumption;
        }

        if (personalComputer.WifiAdapter is not null)
        {
            powerCount += personalComputer.WifiAdapter.PowerConsumption;
        }

        powerCount += personalComputer.Motherboard.MemoryPowerConsumption();
        powerCount += personalComputer.Motherboard.RamPowerConsumption();

        if (personalComputer.PowerUnit.Power <= powerCount)
        {
            return new BuildResult.WithoutGuarantees(personalComputer, new List<string> { "Not enough power of powerUnit" });
        }

        return new BuildResult.Success(personalComputer);
    }
}