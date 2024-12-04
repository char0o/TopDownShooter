using SFML.Graphics;
using TopDownShooter.Components;
using TopDownShooter.Managers;
using TopDownShooter.Util;
using Transform = TopDownShooter.Components.Transform;

namespace TopDownShooter.Systems;

public class WeaponSystem : ISystem
{
    private readonly EntityManager _entityManager;
    private readonly RenderWindow _window;
    private readonly TextureManager _textureManager;

    public WeaponSystem(EntityManager entityManager, RenderWindow window, TextureManager textureManager)
    {
        _entityManager = entityManager;
        _window = window;
        _textureManager = textureManager;
    }

    public void Update(float deltaTime)
    {
        foreach (var entity in _entityManager.GetEntitiesWithComponent<Weapon>())
        {
            Weapon weapon = _entityManager.GetComponent<Weapon>(entity);
            Animation? firingAnimation = _entityManager.GetComponent<Animations>(entity).GetByName("firing");
            Transform transform = _entityManager.GetComponent<Transform>(entity);
            Rendering rendering = _entityManager.GetComponent<Rendering>(entity);
            
            if (weapon.IsFiring)
            {
                firingAnimation.IsPlaying = true;
                
                weapon.TimeAccumulated += deltaTime;
                if (weapon.TimeAccumulated >= weapon.DelayBetweenShots)
                {
                    rendering.Sprite.Texture = _textureManager.GetTexture("Hero_Rifle_Fire.png");
                    weapon.TimeAccumulated -= weapon.DelayBetweenShots;
                    
                    foreach (var bEntity in _entityManager.GetEntitiesWithComponent<BoundingBox>())
                    {
                        BoundingBox bbox = _entityManager.GetComponent<BoundingBox>(bEntity);
                        Ray ray = new Ray(transform.Position, MathHelper.AngleToDirection(transform.Rotation), 1000f);
                        if (_entityManager.GetComponent<PlayerInput>(bEntity) is null
                            && ray.IntersectsBox(bbox.Bounds))
                        {
                            CombatStatus status = _entityManager.GetComponent<CombatStatus>(bEntity);
                            status.Health -= weapon.Damage;
                        }
                    }
                }
            }
            else
            {
                weapon.TimeAccumulated = weapon.DelayBetweenShots;
                firingAnimation.IsPlaying = false;
                rendering.Sprite.Texture = _textureManager.GetTexture("Hero_Rifle.png");
            }
        }
    }
}