using TopDownShooter.Systems;

namespace TopDownShooter.Managers;

public class SystemManager
{
    private readonly IEnumerable<ISystem> _systems;

    public SystemManager(IEnumerable<ISystem> systems)
    {
        _systems = systems;
    }

    public void Update(float deltaTime)
    {
        foreach (var system in _systems)
        {
            system.Update(deltaTime);
        }
    }
}
