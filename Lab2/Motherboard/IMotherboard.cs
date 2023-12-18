namespace Itmo.ObjectOrientedProgramming.Lab2.Motherboard;

public interface IMotherboard<out T>
{
    public bool IsCompatibleWithCpu(Cpu.Cpu cpu);
    public bool IsCompatibleWithRam();
    public bool IsCompatibleWithCooler(CoolingSystem.CoolingSystem coolingSystem);
    public bool IsCompatibleWithVideoCard(VideoCard.VideoCard videoCard);
    public T Clone();
}