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
                _entityManager.DestroyEntity(entity);
            }
        }
    }
}