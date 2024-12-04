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
        foreach (var entity in _entityManager.GetEntitiesWithComponent<FiringAnimation>())
        {
            FiringAnimation animation = _entityManager.GetComponent<FiringAnimation>(entity);

            if (animation.IsPlaying)
            {
                animation.TimeAccumulator += deltaTime;

                if (animation.TimeAccumulator >= animation.TimeBetweenFrames)
                {
                    animation.TimeAccumulator -= animation.TimeBetweenFrames;
                    
                    animation.CurrentFrame = (animation.CurrentFrame + 1) % animation.MaxFrames;
                    
                    animation.Sprite.TextureRect = new IntRect(animation.CurrentFrame * animation.FrameWidth, 0, animation.FrameWidth, animation.Sprite.TextureRect.Height);
                }
            }
        }
    }
}