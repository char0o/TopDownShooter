using SFML.Graphics;
using TopDownShooter.Components;
using TopDownShooter.Managers;
using TopDownShooter.Util;
using Transform = TopDownShooter.Components.Transform;

namespace TopDownShooter.Systems;

public class BulletEffectSystem : ISystem
{
    private readonly EntityManager _entityManager;

    public BulletEffectSystem(EntityManager entityManager)
    {
        _entityManager = entityManager;
    }

    public void Update(float deltaTime)
    {
        foreach (var entity in _entityManager.GetEntitiesWithComponent<Bullet>())
        {
            Bullet bullet = _entityManager.GetComponent<Bullet>(entity);
            Transform transform = _entityManager.GetComponent<Transform>(entity);
            BoundingBox bounds = _entityManager.GetComponent<BoundingBox>(entity);
            
            bullet.TimeAccumulator += deltaTime;

            if (bullet.TimeAccumulator >= bullet.Duration)
            {
                _entityManager.DestroyEntity(entity);
            }
            
            transform.Position += bullet.Direction * deltaTime * 2500.0f;

            foreach (var collideable in _entityManager.GetEntitiesWithComponent<BoundingBox>())
            {
                if (MathHelper.RectsIntersects(bounds.Bounds, _entityManager.GetComponent<BoundingBox>(collideable).Bounds) && collideable != bullet.Owner && collideable != entity)
                {
                    CombatStatus? status = _entityManager.GetComponent<CombatStatus>(collideable);
                    if (status != null)
                    {
                        status.Health -= bullet.Damage;
                    }
                    _entityManager.DestroyEntity(entity);
                }
            }
        }
    }
}