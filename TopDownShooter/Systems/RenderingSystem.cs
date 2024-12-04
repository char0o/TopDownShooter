using System.Numerics;
using SFML.Graphics;
using SFML.System;
using TopDownShooter.Components;
using TopDownShooter.Managers;
using Transform = TopDownShooter.Components.Transform;

namespace TopDownShooter.Systems;

public class RenderingSystem : ISystem
{
    private readonly RenderWindow _window;
    private readonly EntityManager _entityManager;
    private readonly TileMapManager _tileMapManager;

    public RenderingSystem(RenderWindow window, EntityManager entityManager, TileMapManager tileMapManager)
    {
        _window = window;
        _entityManager = entityManager;
        _tileMapManager = tileMapManager;
    }

    public void Update(float deltaTime)
    {
        _tileMapManager.Draw();
        foreach (int entity in _entityManager.GetEntitiesWithComponent<Rendering>())
        {
            Rendering? rendering = _entityManager.GetComponent<Rendering>(entity);
            Transform? transform = _entityManager.GetComponent<Transform>(entity);
            WalkingAnimation? walkingAnimation = _entityManager.GetComponent<WalkingAnimation>(entity);
            FiringAnimation? firingAnimation = _entityManager.GetComponent<FiringAnimation>(entity);
            BoundingBox? boundingBox = _entityManager.GetComponent<BoundingBox>(entity);

            if (rendering is not null && transform is not null)
            {
                rendering.Sprite.Position = transform.Position;// - (transform.Scale * PLAYER_SPRITE_SIZE / 2);
                rendering.Sprite.Rotation = transform.Rotation;
                rendering.Sprite.Scale = transform.Scale;
                rendering.Sprite.Origin = new Vector2f(rendering.Sprite.TextureRect.Width / 2, rendering.Sprite.TextureRect.Height / 2);
                
                
                
                if (walkingAnimation is not null)
                {
                    walkingAnimation.Sprite.Position = rendering.Sprite.Position;
                    walkingAnimation.Sprite.Rotation = rendering.Sprite.Rotation;
                    walkingAnimation.Sprite.Scale = rendering.Sprite.Scale;
                    walkingAnimation.Sprite.Origin = new Vector2f(walkingAnimation.Sprite.TextureRect.Width / 2, walkingAnimation.Sprite.TextureRect.Height / 2);
                    
                    _window.Draw(walkingAnimation.Sprite);
                }
                
                if (firingAnimation is not null && firingAnimation.IsPlaying)
                {
                    firingAnimation.Sprite.Position = rendering.Sprite.Position;
                    firingAnimation.Sprite.Rotation = rendering.Sprite.Rotation;
                    firingAnimation.Sprite.Scale = rendering.Sprite.Scale;
                    firingAnimation.Sprite.Origin = new Vector2f(firingAnimation.Sprite.TextureRect.Width / 2 + 3f, firingAnimation.Sprite.TextureRect.Height / 2 - 29f);
                    _window.Draw(firingAnimation.Sprite);
                }

                if (boundingBox is not null)
                {
                    boundingBox.Bounds = new FloatRect(rendering.Sprite.Position - rendering.Sprite.Origin, (Vector2f)rendering.Sprite.TextureRect.Size);

                    boundingBox.Rectangle.Size = boundingBox.Bounds.Size;
                    boundingBox.Rectangle.Position = boundingBox.Bounds.Position;
                    //boundingBox.Rectangle.Origin = rendering.Sprite.Origin;
                    
                    _window.Draw(boundingBox.Rectangle);
                }
                _window.Draw(rendering.Sprite);
            }
        }
    }

}