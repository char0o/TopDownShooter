using SFML.Graphics;
using TopDownShooter.Components;
using TopDownShooter.Managers;

namespace TopDownShooter.Systems;

public class WeaponSystem : ISystem
{
    private readonly EntityManager _entityManager;
    private readonly RenderWindow _window;

    public WeaponSystem(EntityManager entityManager)
    {
        _entityManager = entityManager;
    }

    public void Update(float deltaTime)
    {
        foreach (var entity in _entityManager.GetEntitiesWithComponent<Weapon>())
        {
            Weapon weapon = _entityManager.GetComponent<Weapon>(entity);
            FiringAnimation firingAnimation = _entityManager.GetComponent<FiringAnimation>(entity);

            if (weapon.IsFiring)
            {
                firingAnimation.IsPlaying = true;
                weapon.TimeAccumulated += deltaTime;

                if (weapon.TimeAccumulated >= weapon.DelayBetweenShots)
                {
                    Console.WriteLine("Entity fired");
                    weapon.TimeAccumulated -= weapon.DelayBetweenShots;
                    
                }
            }
            else
            {
                weapon.TimeAccumulated = weapon.DelayBetweenShots;
                firingAnimation.IsPlaying = false;
            }
        }
    }
}