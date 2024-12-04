using SFML.System;
using TopDownShooter.Components;
using TopDownShooter.Managers;
using TopDownShooter.Util;

namespace TopDownShooter.Systems;

public class PlayerController : ISystem
{
    private readonly EntityManager _entityManager;
    private const float MOVESPEED = 500f;
    private int localPlayer = -1;

    public PlayerController(EntityManager entityManager)
    {
        _entityManager = entityManager;
        localPlayer = _entityManager.GetEntitiesWithComponent<PlayerInput>().FirstOrDefault();
    }
    

    public void Update(float deltaTime)
    {
        foreach (int entity in _entityManager.GetEntitiesWithComponent<PlayerInput>())
        {
            PlayerInput? playerInput = _entityManager.GetComponent<PlayerInput>(entity);
            Velocity? velocity = _entityManager.GetComponent<Velocity>(entity);
            Transform? transform = _entityManager.GetComponent<Transform>(entity);
            Animations? animations = _entityManager.GetComponent<Animations>(entity);
            Weapon? weapon = _entityManager.GetComponent<Weapon>(entity);

            if (playerInput is not null && velocity is not null && transform is not null && weapon is not null && animations is not null)
            {
                if (playerInput.MoveLeft)
                {
                    velocity = new Velocity(new Vector2f(-MOVESPEED, velocity.Value.Y));
                }

                if (playerInput.MoveRight)
                {
                    velocity = new Velocity(new Vector2f(MOVESPEED, velocity.Value.Y));
                }

                if (playerInput.MoveUp)
                {
                    velocity = new Velocity(new Vector2f(velocity.Value.X, -MOVESPEED));
                }

                if (playerInput.MoveDown)
                {
                    velocity = new Velocity(new Vector2f(velocity.Value.X, MOVESPEED));
                }
                
                Animation? walkingAnimation = animations.GetByName("walking");
                if (playerInput.IsMoving)
                {
                    walkingAnimation.IsPlaying = true;
                }
                else
                {
                    walkingAnimation.IsPlaying = false;
                }


                transform.Position += velocity.Value * deltaTime;
            }
        }
    }
}