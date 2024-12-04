using SFML.Graphics;
using SFML.System;
using TopDownShooter.Managers;

namespace TopDownShooter;

public class Game
{
    public static Vector2f ScreenSize => new(1600, 900);
    private readonly RenderWindow _window;
    private readonly SystemManager _systemManager;
    private readonly GameManager _gameManager;

    public Game(RenderWindow window, SystemManager systemManager, GameManager gameManager)
    {
        _window = window;
        _systemManager = systemManager;
        _gameManager = gameManager;
    }

    public void Run()
    {
        Clock clock = new Clock();
        _window.Closed += (_, _) => _window.Close();
        _gameManager.Initialize();
        
        while (_window.IsOpen)
        {
            float dt = clock.Restart().AsSeconds();
            _window.DispatchEvents();
            _window.Clear();
            _systemManager.Update(dt);
            _window.Display();
        }
    }
}