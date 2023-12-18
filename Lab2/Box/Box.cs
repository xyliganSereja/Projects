using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.FormFactor;
using Itmo.ObjectOrientedProgramming.Lab2.VideoCard;

namespace Itmo.ObjectOrientedProgramming.Lab2.Box;

public class Box : IBox<Box>
{
    private Box(FormFactors formFactor, int maxVideoCardLength, int maxVideoCardWidth)
    {
        FormFactor = formFactor;
        MaxVideoCardLength = maxVideoCardLength;
        MaxVideoCardWidth = maxVideoCardWidth;
    }

    public FormFactors FormFactor { get; }
    public int MaxVideoCardLength { get; }
    public int MaxVideoCardWidth { get; }

    public static Box SmallBox(int maxVideoCardLength, int maxVideoCardWidth)
    {
        return new Box(FormFactors.Low, maxVideoCardLength, maxVideoCardWidth);
    }

    public static Box MiddleBox(int maxVideoCardLength, int maxVideoCardWidth)
    {
        return new Box(FormFactors.Mid, maxVideoCardLength, maxVideoCardWidth);
    }

    public static Box HugeBox(int maxVideoCardLength, int maxVideoCardWidth)
    {
        return new Box(FormFactors.Huge, maxVideoCardLength, maxVideoCardWidth);
    }

    public bool IsCompatibleWithVideoCard(IVideoCard<VideoCard.VideoCard>? videoCard)
    {
        if (videoCard is null)
        {
            throw new VideoCardException("Video card is null");
        }

        return MaxVideoCardLength >= videoCard.VideoCardLength && MaxVideoCardWidth >= videoCard.VideoCardWidth;
    }

    public Box Clone()
    {
        return new Box(FormFactor, MaxVideoCardLength, MaxVideoCardWidth);
    }
}