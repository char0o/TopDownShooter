using SFML.Graphics;
using SFML.Window;
using TopDownShooter.Components;
using TopDownShooter.Managers;

namespace TopDownShooter.Systems;

public class MouseInput : ISystem
{
    private readonly EntityManager _entityManager;
    private readonly RenderWindow _window;

    public MouseInput(EntityManager entityManager, RenderWindow window)
    {
        _entityManager = entityManager;
        _window = window;
    }

    public void Update(float deltaTime)
    {
        foreach (int entity in _entityManager.GetEntitiesWithComponent<PlayerInput>())
        {
            Weapon weapon = _entityManager.GetComponent<Weapon>(entity);

            if (_window.HasFocus())
            {   
                weapon.IsFiring = Mouse.IsButtonPressed(Mouse.Button.Left);
            }
        }
    }
}