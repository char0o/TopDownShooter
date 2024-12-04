using TopDownShooter.Components;
using TopDownShooter.Managers;

namespace TopDownShooter.Systems;

public class MovementSystem : ISystem
{
    private readonly EntityManager _entityManager;

    public MovementSystem(EntityManager entityManager)
    {
        _entityManager = entityManager;
    }

    public void Update(float deltaTime)
    {
        foreach (int entity in _entityManager.GetEntitiesWithComponent<Velocity>())
        {
            Velocity? velocity = _entityManager.GetComponent<Velocity>(entity);
            Transform? transform = _entityManager.GetComponent<Transform>(entity);

            if (velocity is not null && transform is not null)
            {
                transform.Position += velocity.Value * deltaTime;
            }
        }
    }
}