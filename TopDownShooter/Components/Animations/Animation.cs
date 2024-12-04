using SFML.Graphics;
using SFML.System;

namespace TopDownShooter.Components;

public class Animation
{
    public string AnimationName { get; set; } = string.Empty;
    public Sprite Sprite { get; set; }
    public int MaxFrames { get; set; }
    public float TimeBetweenFrames { get; set; }
    public bool IsPlaying { get; set; } = false;
    public int CurrentFrame { get; set; }
    public float TimeAccumulator { get; set; }
    public int StartingFrame { get; set; }
    public int FrameWidth { get; set; }
    public Vector2f PositionOffset { get; set; } = new();

    public Animation(string animationName, Sprite sprite, int startingFrame, int maxFrames, float timeBetweenFrames)
    {
        AnimationName = animationName;
        Sprite = sprite;
        TimeBetweenFrames = timeBetweenFrames;
        MaxFrames = maxFrames;
        CurrentFrame = 0;
        TimeAccumulator = TimeBetweenFrames;
        StartingFrame = startingFrame;
    }
}