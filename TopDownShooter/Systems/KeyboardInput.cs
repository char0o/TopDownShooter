using SFML.Graphics;
using SFML.Window;
using TopDownShooter.Components;
using TopDownShooter.Managers;

namespace TopDownShooter.Systems;

public class KeyboardInput : ISystem
{
    private readonly EntityManager _entityManager;
    private readonly RenderWindow _window;

    public KeyboardInput(EntityManager entityManager, RenderWindow window)
    {
        _entityManager = entityManager;
        _window = window;
    }

    public void Update(float deltaTime)
    {
        foreach (int entity in _entityManager.GetEntitiesWithComponent<PlayerInput>())
        {
            PlayerInput playerInput = _entityManager.GetComponent<PlayerInput>(entity);

            if (_window.HasFocus())
            {   
                playerInput.MoveRight = Keyboard.IsKeyPressed(Keyboard.Key.D);
                playerInput.MoveUp = Keyboard.IsKeyPressed(Keyboard.Key.W);
                playerInput.MoveDown = Keyboard.IsKeyPressed(Keyboard.Key.S);
                playerInput.MoveLeft = Keyboard.IsKeyPressed(Keyboard.Key.A);
            }
        }
    }
}