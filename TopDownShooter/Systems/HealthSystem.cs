using SFML.Graphics;
using SFML.System;
using TopDownShooter.Components;
using TopDownShooter.Managers;

namespace TopDownShooter.Systems;

public class HealthSystem : ISystem
{
    private readonly EntityManager _entityManager;

    public HealthSystem(EntityManager entityManager)
    {
        _entityManager = entityManager;
    }

    public void Update(float deltaTime)
    {
        foreach (var entity in _entityManager.GetEntitiesWithComponent<CombatStatus>())
        {
            CombatStatus status = _entityManager.GetComponent<CombatStatus>(entity);
            
            if (!status.IsAlive)
            {
                Velocity? velocity = _entityManager.GetComponent<Velocity>(entity);
                if (velocity != null)
                {
                    velocity.Value = new Vector2f(0, 0);
                }
                BoundingBox? boundingBox = _entityManager.GetComponent<BoundingBox>(entity);
                if (boundingBox != null)
                {
                    _entityManager.RemoveComponent(entity, boundingBox);
                }
                Rendering rendering = _entityManager.GetComponent<Rendering>(entity);
                if (rendering is not null)
                {
                    rendering.Sprite.Color = new Color();
                }
                
                Animations animations = _entityManager.GetComponent<Animations>(entity);
                foreach (Animation animation in animations)
                {
                    if (animation.IsPlaying)
                    {
                        animation.IsPlaying = false;
                    }

                    if (animation.AnimationName == "dying" && !animation.IsPlaying)
                    {
                        animation.IsPlaying = true;
                    }
                }
                
            }
        }
    }
}