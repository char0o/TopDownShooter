using SFML.Graphics;
using TopDownShooter.Components;
using TopDownShooter.Managers;

namespace TopDownShooter.Systems;

public class AnimationSystem : ISystem
{
    private readonly EntityManager _entityManager;

    public AnimationSystem(EntityManager entityManager)
    {
        _entityManager = entityManager;
    }

    public void Update(float deltaTime)
    {
        foreach (var entity in _entityManager.GetEntitiesWithComponent<Animations>())
        {
            Animations? animations = _entityManager.GetComponent<Animations>(entity);

            if (animations is not null)
            {
                foreach (Animation animation in animations.Values)
                {
                    animation.TimeAccumulator += deltaTime;

                    if (animation.TimeAccumulator >= animation.TimeBetweenFrames)
                    {
                        animation.TimeAccumulator -= animation.TimeBetweenFrames;
                        if (animation.Loop)
                        {
                            animation.CurrentFrame = (animation.CurrentFrame + 1) % animation.MaxFrames;
                        }
                        else 
                        {
                            if (animation.CurrentFrame != animation.MaxFrames - 1)
                            {
                                animation.CurrentFrame++;
                            }
                            else
                            {
                                animation.Finished = true;
                            }
                        }

                        animation.Sprite.TextureRect = new IntRect(animation.CurrentFrame * animation.FrameWidth, 0, 
                            animation.FrameWidth, animation.Sprite.TextureRect.Height);
                    }
                }
            }
        }
    }
}