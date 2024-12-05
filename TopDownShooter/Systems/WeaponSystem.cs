using SFML.Graphics;
using SFML.System;
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
        foreach (var entity in _entityManager.GetEntitiesWithComponent<Weapon>().ToList())
        {
            Weapon? weapon = _entityManager.GetComponent<Weapon>(entity);
            Animations? animations = _entityManager.GetComponent<Animations>(entity);
            Transform? transform = _entityManager.GetComponent<Transform>(entity);
            Rendering? rendering = _entityManager.GetComponent<Rendering>(entity);
            
            if(weapon is null || transform is null || rendering is null || animations is null)
                continue;
            Vector2f playerDirection = MathHelper.AngleToDirection(transform.Rotation);
            Animation? firingAnimation = animations.GetByName("firing");
            if (firingAnimation is not null && weapon.IsFiring)
            {
                firingAnimation.IsPlaying = true;
                
                weapon.TimeAccumulated += deltaTime;
                if (weapon.TimeAccumulated >= weapon.DelayBetweenShots)
                {
                    rendering.Sprite.Texture = _textureManager.GetTexture("Hero_Rifle_Fire.png");
                    int bulletId = _entityManager.CreateEntity();
                    _entityManager.AddComponent(bulletId,
                        new Bullet(transform.Position, playerDirection, 10f, 5f, weapon.Owner, 10));
                    _entityManager.AddComponent(bulletId, new SquareRendering(new RectangleShape(new Vector2f(8, 1))));
                    _entityManager.AddComponent(bulletId, new Transform(transform.Position, transform.Rotation, new Vector2f(1, 1)));
                    _entityManager.AddComponent(bulletId, new BoundingBox());
                    
                    weapon.TimeAccumulated -= weapon.DelayBetweenShots;
                    
                    foreach (var bEntity in _entityManager.GetEntitiesWithComponent<BoundingBox>())
                    {
                        BoundingBox? bbox = _entityManager.GetComponent<BoundingBox>(bEntity);
                        if (bbox is null)
                            continue;
                        Ray ray = new Ray(transform.Position, MathHelper.AngleToDirection(transform.Rotation), 1000f);
                        if (_entityManager.GetComponent<PlayerInput>(bEntity) is null
                            && ray.IntersectsBox(bbox.Bounds))
                        {
                            CombatStatus? status = _entityManager.GetComponent<CombatStatus>(bEntity);
                            if (status is null)
                                continue;
                            //status.Health -= weapon.Damage;
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