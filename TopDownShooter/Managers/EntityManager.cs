namespace TopDownShooter.Managers;

public class EntityManager
{
    private readonly Dictionary<int, Dictionary<Type, object>> _entities = new();
    private int _nextEntityId = 0;

    public int CreateEntity()
    {
        var id = _nextEntityId++;
        _entities[id] = new Dictionary<Type, object>();
        return id;
    }

    public void DestroyEntity(int id)
    {
        if (_entities.ContainsKey(id))
        {
            _entities.Remove(id);
        }
        else
        {
            throw new InvalidOperationException($"Entity with id {id} does not exist.");
        }
    }
    
    public void AddComponent<T>(int entityId, T component)
    {
        _entities[entityId][typeof(T)] = component;
    }

    public T? GetComponent<T>(int entityId) where T : class
    {
        return _entities[entityId].TryGetValue(typeof(T), out var component) ? component as T : null;
    }

    public IEnumerable<int> GetEntities()
    {
        return _entities.Keys;
    }

    public void RemoveComponent<T>(int entityId, T component)
    {
        _entities[entityId].Remove(component.GetType());
    }
    public IEnumerable<int> GetEntitiesWithComponent<T>()
    {
        return _entities.Where(e => e.Value.ContainsKey(typeof(T))).Select(e => e.Key);
    }
}
