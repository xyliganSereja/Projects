using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Space;

namespace Itmo.ObjectOrientedProgramming.Lab1.Expedition;

public static class MyExpedition
{
    public static int BestOf(MySpace space, params Spaceship[]? ships)
    {
        if (ships is null)
        {
            throw new ArgumentException("null ships array");
        }

        if (space is null)
        {
            throw new SpaceException("null space");
        }

        int[] costs = new int[ships.Length];
        int index = 0;
        return ships.Select(ship =>
        {
            ExpeditionSimulation(ship, space.Clone(), ref costs[index]);
            return (index, costs[index++]);
        }).OrderBy(x => x.Item2).FirstOrDefault().index + 1;
    }

    public static string ExpeditionSimulation(Spaceship? spaceship, MySpace? space, ref int fuel)
    {
        if (space is null || spaceship is null)
        {
            throw new ExpeditionException("Spaceship or space is null");
        }

        States state = States.Success;
        while (space.HasNext())
        {
            AbstractSpace next = space.GetNext();
            if (next.IsDefaultSpace())
            {
                var defaultSpace = (DefaultSpace)next;
                while (defaultSpace.HaveObstacles())
                {
                    if (!spaceship.TryToDeflect(defaultSpace.Next()))
                    {
                        return ThirdResult();
                    }
                }

                state = spaceship.TryToFly(defaultSpace) ? state : States.LostInSpace;
            }
            else if (next.IsFogSpace())
            {
                var fogSpace = (FogSpace)next;
                while (fogSpace.HaveObstacles())
                {
                    state = spaceship.TryToDeflect(fogSpace.Next()) ? state : States.DeadCrew;
                }

                state = spaceship.TryToJump(fogSpace) ? state : States.LostInSpace;
            }
            else if (next.IsNitrineSpace())
            {
                var nitrineSpace = (NitrineSpace)next;
                while (nitrineSpace.HaveObstacles())
                {
                    if (!spaceship.TryToDeflect(nitrineSpace.Next()))
                    {
                        return ThirdResult();
                    }
                }

                state = spaceship.TryToFlyInNitrine(nitrineSpace) ? state : States.LostInSpace;
            }
            else
            {
                throw new ObstaclesException("Unsupported obstacle type");
            }
        }

        if (!(state == States.Success))
        {
            fuel = int.MaxValue;
        }

        switch (state)
        {
            case States.Success:
            {
                fuel = (int)spaceship.FuelConsumed();
                return FirstResult(spaceship.TravelTime(), fuel);
            }

            case States.LostInSpace: return SecondResult();
            case States.DeadCrew: return FourthResult();
            default: throw new ExpeditionException("Unsupported state");
        }
    }

    public static string FirstResult(double time, double fuel)
    {
        return "The expedition was successful\nTime: " + (int)time +
               "\nFuel Consumed: " + (int)fuel;
    }

    public static string SecondResult()
    {
        return "The spaceship was lost";
    }

    public static string ThirdResult()
    {
        return "The spaceship was destroyed";
    }

    public static string FourthResult()
    {
        return "The crew was killed";
    }
}