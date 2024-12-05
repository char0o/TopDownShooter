using SFML.System;
using TopDownShooter.Components;
using TopDownShooter.Managers;
using TopDownShooter.Util;

namespace TopDownShooter.Systems;

public class RandomAiSystem : ISystem
{
    private readonly EntityManager _entityManager;

    public RandomAiSystem(EntityManager entityManager)
    {
        _entityManager = entityManager;
    }

    public void Update(float deltaTime)
    {
        foreach (var entity in _entityManager.GetEntitiesWithComponent<Ai>())
        {
            Velocity? velocity = _entityManager.GetComponent<Velocity>(entity);
            Transform? entityTransform = _entityManager.GetComponent<Transform>(entity);
            Animations? animations = _entityManager.GetComponent<Animations>(entity);
            CombatStatus? combatStatus = _entityManager.GetComponent<CombatStatus>(entity);

            int? playerId = _entityManager.GetEntitiesWithComponent<PlayerInput>().FirstOrDefault();

            if (combatStatus == null || !combatStatus.IsAlive)
            {
                continue;
            }
            
            if (velocity is not null && playerId is not null)
            {
                Transform? playerTransform = _entityManager.GetComponent<Transform>(playerId.Value);
                Vector2f direction = playerTransform.Position - entityTransform.Position;
                velocity.Value = MathHelper.Normalize(direction) * 100f;
                
                float angle = MathF.Atan2(direction.Y, direction.X);
                float deg = angle / MathF.PI * 180;
                
                entityTransform.Rotation = deg;
            }

            if (animations is not null)
            {
                foreach (Animation animation in animations)
                {
                    if (animation.AnimationName == "walking")
                    {
                        animation.IsPlaying = true;
                    }
                }
            }
        }
    }
}