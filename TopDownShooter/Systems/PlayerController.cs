using SFML.System;
using TopDownShooter.Components;
using TopDownShooter.Managers;

namespace TopDownShooter.Systems;

public class PlayerController : ISystem
{
    private readonly EntityManager _entityManager;
    private const float MOVESPEED = 500f;

    public PlayerController(EntityManager entityManager)
    {
        _entityManager = entityManager;
    }

    public void Update(float deltaTime)
    {
        foreach (int entity in _entityManager.GetEntitiesWithComponent<PlayerInput>())
        {
            PlayerInput playerInput = _entityManager.GetComponent<PlayerInput>(entity);
            Velocity velocity = _entityManager.GetComponent<Velocity>(entity);
            Transform transform = _entityManager.GetComponent<Transform>(entity);
            WalkingAnimation walkingAnimation = _entityManager.GetComponent<WalkingAnimation>(entity);
            FiringAnimation firingAnimation = _entityManager.GetComponent<FiringAnimation>(entity);
            Weapon weapon = _entityManager.GetComponent<Weapon>(entity);

            if (playerInput is not null && velocity is not null && transform is not null && walkingAnimation is not null && firingAnimation is not null && weapon is not null)
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

                if (playerInput.IsMoving)
                {
                    walkingAnimation.Update(deltaTime);
                }
                else
                {
                    walkingAnimation.Reset();
                }
                Console.WriteLine(weapon.IsFiring);
                if (weapon.IsFiring)
                {
                    firingAnimation.Update(deltaTime);
                }
                else
                {
                    firingAnimation.Reset();
                }
                transform.Position += velocity.Value * deltaTime;
            }
        }
    }
}