using SFML.Graphics;

namespace TopDownShooter.Components;

public class WalkingAnimation
{
    public Sprite Sprite { get; set; }
    public int MaxFrames { get; set; }
    public float TimeBetweenFrames { get; set; }
    public int CurrentFrame { get; private set; }
    public float TimeAccumulator { get; private set; }
    public int StartingFrame { get; private set; }
    private readonly int _frameWidth;

    public WalkingAnimation(Sprite sprite, int startingFrame, int maxFrames, float timeBetweenFrames)
    {
        Sprite = sprite;
        TimeBetweenFrames = timeBetweenFrames;
        MaxFrames = maxFrames;
        CurrentFrame = 0;
        TimeAccumulator = 0;
        StartingFrame = startingFrame;
        _frameWidth = (int)Sprite.TextureRect.Width / MaxFrames;
        Sprite.TextureRect = new IntRect(StartingFrame * _frameWidth, 0, _frameWidth, Sprite.TextureRect.Height);
    }

    public void Reset()
    {
        CurrentFrame = StartingFrame;
        TimeAccumulator = 0;
        Sprite.TextureRect = new IntRect(StartingFrame * _frameWidth, 0, _frameWidth, Sprite.TextureRect.Height);
    }
    
    public void Update(float deltaTime)
    {
        TimeAccumulator += deltaTime;

        if (TimeAccumulator >= TimeBetweenFrames)
        {
            TimeAccumulator -= TimeBetweenFrames;
            CurrentFrame = (CurrentFrame + 1) % MaxFrames;
            
            Sprite.TextureRect = new IntRect(CurrentFrame * _frameWidth, 0, _frameWidth, Sprite.TextureRect.Height);
        }
    }
}