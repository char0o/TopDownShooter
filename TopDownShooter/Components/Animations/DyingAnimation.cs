using SFML.Graphics;
using SFML.System;

namespace TopDownShooter.Components;

public class DyingAnimation : Animation
{
    public DyingAnimation(string animationName, Sprite sprite, int startingFrame, int maxFrames, float timeBetweenFrames) : base(animationName, sprite, startingFrame, maxFrames, timeBetweenFrames)
    {
        FrameWidth = Sprite.TextureRect.Width / MaxFrames;
        Sprite.TextureRect = new IntRect(100, 0, FrameWidth, Sprite.TextureRect.Height);
    }
}