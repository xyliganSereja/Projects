using Itmo.ObjectOrientedProgramming.Lab2.VideoCard;

namespace Itmo.ObjectOrientedProgramming.Lab2.Box;

public interface IBox<out T>
{
    public bool IsCompatibleWithVideoCard(IVideoCard<VideoCard.VideoCard> videoCard);
    public T Clone();
}