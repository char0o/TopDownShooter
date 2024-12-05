using SFML.Graphics;
using SFML.System;
using TopDownShooter.Components;
using Transform = TopDownShooter.Components.Transform;

namespace TopDownShooter.Managers;

public class GameManager
{
    private readonly EntityManager _entityManager;
    private readonly TextureManager _textureManager;

    public GameManager(EntityManager entityManager, TextureManager textureManager)
    {
        _entityManager = entityManager;
        _textureManager = textureManager;
    }

    public void Initialize()
    {
        int e = _entityManager.CreateEntity();
        _entityManager.AddComponent(e, new Rendering(new Sprite(_textureManager.GetTexture("Hero_Rifle.png"))));
        _entityManager.AddComponent(e, new Transform(new Vector2f(300, 300), 90.0f, new Vector2f(2, 2)));
        _entityManager.AddComponent(e, new Velocity(new Vector2f(0, 0)));
        _entityManager.AddComponent(e, new PlayerInput());
        Weapon weapon = new Weapon()
        {
            DelayBetweenShots = 0.1f,
            Damage = 5,
            Owner = e
        };
        FiringAnimation firingAnimation = new FiringAnimation("firing",
            new Sprite(_textureManager.GetTexture("firing_animation.png")), 0, 3, 0.10f);
        firingAnimation.Loop = true;
        WalkingAnimation walkingAnimation = new WalkingAnimation("walking",
            new Sprite(_textureManager.GetTexture("hero_animation.png")), 2, 7, 0.10f);
        walkingAnimation.Loop = true;
        Animations playerAnimations = new Animations();
        playerAnimations.Add(firingAnimation);
        playerAnimations.Add(walkingAnimation);
        _entityManager.AddComponent(e, playerAnimations);
        _entityManager.AddComponent(e, weapon);
        _entityManager.AddComponent(e, new BoundingBox());
        _entityManager.AddComponent(e, new CombatStatus() { Health = 100 });
        
        
        
        int ee = _entityManager.CreateEntity();
        _entityManager.AddComponent(ee, new Rendering(new Sprite(_textureManager.GetTexture("Hero_Flamethrower.png"))));
        _entityManager.AddComponent(ee, new Transform(new Vector2f(15, 15), 0.0f, new Vector2f(2, 2)));
        _entityManager.AddComponent(ee, new Velocity(new Vector2f()));
        Animations aiAnimations = new Animations();
        FiringAnimation aifiringAnimation = new FiringAnimation("firing",
            new Sprite(_textureManager.GetTexture("firing_animation.png")), 0, 3, 0.10f);
        aifiringAnimation.Loop = true;
        WalkingAnimation aiwalkingAnimation = new WalkingAnimation("walking",
            new Sprite(_textureManager.GetTexture("hero_animation.png")), 2, 7, 0.10f);
        aiwalkingAnimation.Loop = true;
        DyingAnimation dyingAnimation = new DyingAnimation("dying",
            new Sprite(_textureManager.GetTexture("hero_die_animation.png")), 0, 4, 0.5f);
        aiAnimations.Add(aifiringAnimation);
        aiAnimations.Add(aiwalkingAnimation);
        aiAnimations.Add(dyingAnimation);
        _entityManager.AddComponent(ee, aiAnimations);
        _entityManager.AddComponent(ee, new BoundingBox());
        _entityManager.AddComponent(ee, new CombatStatus() { Health = 100 });
        _entityManager.AddComponent(ee, new Ai());

        int camera = _entityManager.CreateEntity();
        _entityManager.AddComponent(camera, new Camera());
    }
}