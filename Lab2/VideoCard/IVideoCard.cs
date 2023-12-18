namespace Itmo.ObjectOrientedProgramming.Lab2.VideoCard;

public interface IVideoCard<out T>
{
    public int VideoCardLength { get; }
    public int VideoCardWidth { get; }
    public T Clone();
}