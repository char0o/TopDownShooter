using SFML.Graphics;

namespace TopDownShooter.Components;

public class FiringAnimation
{
    public Sprite Sprite { get; set; }
    public int MaxFrames { get; set; }
    public float TimeBetweenFrames { get; set; }
    public bool IsPlaying { get; set; } = false;
    public int CurrentFrame { get; set; }
    public float TimeAccumulator { get; set; }
    public int StartingFrame { get; set; }
    public int FrameWidth { get; set; }

    public FiringAnimation(Sprite sprite, int startingFrame, int maxFrames, float timeBetweenFrames)
    {
        Sprite = sprite;
        TimeBetweenFrames = timeBetweenFrames;
        MaxFrames = maxFrames;
        CurrentFrame = 0;
        TimeAccumulator = TimeBetweenFrames;
        StartingFrame = startingFrame;
        FrameWidth = Sprite.TextureRect.Width / MaxFrames;
        Sprite.TextureRect = new IntRect(100, 0, FrameWidth, Sprite.TextureRect.Height);
    }


}