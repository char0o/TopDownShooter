using SFML.Graphics;

namespace TopDownShooter.Components;

public class WalkingAnimation : Animation
{
    public WalkingAnimation(string animationName, Sprite sprite, int startingFrame, int maxFrames, float timeBetweenFrames) : base(animationName, sprite, startingFrame, maxFrames, timeBetweenFrames)
    {
        FrameWidth = Sprite.TextureRect.Width / MaxFrames;
        Sprite.TextureRect = new IntRect(StartingFrame * FrameWidth, 0, FrameWidth, Sprite.TextureRect.Height);
    }
}