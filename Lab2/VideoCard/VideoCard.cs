namespace Itmo.ObjectOrientedProgramming.Lab2.VideoCard;

public class VideoCard : IVideoCard<VideoCard>
{
    public VideoCard(int videoCardLength, int videoCardWidth, string pciVersion, int chipFrequency, int powerConsumption)
    {
        VideoCardLength = videoCardLength;
        VideoCardWidth = videoCardWidth;
        PciVersion = pciVersion;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
    }

    public int VideoCardLength { get; }
    public int VideoCardWidth { get; }
    public string PciVersion { get; }
    public int ChipFrequency { get; }
    public int PowerConsumption { get; }

    public VideoCard Clone()
    {
        return new VideoCard(VideoCardLength, VideoCardWidth, PciVersion, ChipFrequency, PowerConsumption);
    }
}