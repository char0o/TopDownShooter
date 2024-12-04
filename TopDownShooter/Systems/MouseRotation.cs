using SFML.Graphics;
using SFML.System;
using SFML.Window;
using TopDownShooter.Components;
using TopDownShooter.Managers;
using Transform = TopDownShooter.Components.Transform;

namespace TopDownShooter.Systems;

public class MouseRotation : ISystem
{
    private readonly EntityManager _entityManager;
    private readonly RenderWindow _window;

    public MouseRotation(EntityManager entityManager, RenderWindow window)
    {
        _entityManager = entityManager;
        _window = window;
    }

    public void Update(float deltaTime)
    {
        Vector2i mousePosition = Mouse.GetPosition(_window);
        Vector2f mouseWorldPosition = _window.MapPixelToCoords(mousePosition);
        foreach (int entity in _entityManager.GetEntitiesWithComponent<PlayerInput>())
        {
            Transform playerTransform = _entityManager.GetComponent<Transform>(entity);
            
            Vector2f direction = mouseWorldPosition - playerTransform.Position;

            float angle = MathF.Atan2(direction.Y, direction.X);
            float deg = angle * 180f / MathF.PI;
            playerTransform.Rotation = deg - 90f;
        }
    }
}