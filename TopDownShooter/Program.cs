using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using TopDownShooter.Components;
using TopDownShooter.Managers;
using TopDownShooter.Systems;
using Transform = TopDownShooter.Components.Transform;

namespace TopDownShooter;

class Program
{
    static void Main(string[] args)
    {
        ServiceCollection serviceCollection = new ServiceCollection();
        
        RenderWindow window = new RenderWindow(new VideoMode((uint)Game.ScreenSize.X, (uint)Game.ScreenSize.Y), "Top Down Shooter");
        
        serviceCollection.AddSingleton<RenderWindow>(window);
        serviceCollection.AddTransient<ISystem, RenderingSystem>();
        serviceCollection.AddTransient<ISystem, MovementSystem>();
        serviceCollection.AddTransient<ISystem, PlayerController>();
        serviceCollection.AddTransient<ISystem, KeyboardInput>();
        serviceCollection.AddTransient<ISystem, CameraSystem>();
        serviceCollection.AddTransient<ISystem, MouseRotation>();
        serviceCollection.AddTransient<ISystem, MouseInput>();
        serviceCollection.AddTransient<ISystem, WeaponSystem>();
        serviceCollection.AddTransient<ISystem, AnimationSystem>();
        serviceCollection.AddTransient<ISystem, HealthSystem>();
        serviceCollection.AddTransient<ISystem, RandomAiSystem>();
        serviceCollection.AddTransient<ISystem, BulletEffectSystem>();
        
        serviceCollection.AddSingleton<EntityManager>();
        serviceCollection.AddSingleton<TextureManager>();
        serviceCollection.AddSingleton<SystemManager>();
        serviceCollection.AddSingleton<GameManager>();
        serviceCollection.AddSingleton<TileMapManager>();
        serviceCollection.AddSingleton<Game>();
        
        ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
        
        Game game = serviceProvider.GetRequiredService<Game>();
        game.Run();
    }
}