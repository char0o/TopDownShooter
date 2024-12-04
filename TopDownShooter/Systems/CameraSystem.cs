using SFML.Graphics;
using TopDownShooter.Components;
using TopDownShooter.Managers;
using Transform = TopDownShooter.Components.Transform;

namespace TopDownShooter.Systems;

public class CameraSystem : ISystem
{
    private readonly EntityManager _entityManager;
    private readonly RenderWindow _window;

    public CameraSystem(EntityManager entityManager, RenderWindow window)
    {
        _entityManager = entityManager;
        _window = window;
    }

    public void Update(float deltaTime)
    {
        int player = -1;
        foreach (int entity in _entityManager.GetEntitiesWithComponent<PlayerInput>())
        {
            player = entity;
        }

        if (player != -1)
        {
            foreach (int entity in _entityManager.GetEntitiesWithComponent<Camera>())
            {
                Camera camera = _entityManager.GetComponent<Camera>(entity);
                Transform playerTransform = _entityManager.GetComponent<Transform>(player);

                if (camera is not null && playerTransform is not null)
                {
                    camera.View.Center = playerTransform.Position;
                    _window.SetView(camera.View);
                }
            }
        }
    }
}