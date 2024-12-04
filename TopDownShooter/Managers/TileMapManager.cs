using SFML.Graphics;
using SFML.System;

namespace TopDownShooter.Managers;

public class TileMapManager
{
    private readonly RenderWindow _window;
    private readonly TextureManager _textureManager;
    
    private readonly List<Sprite[,]> _tileMaps;
    private const int TILE_SIZE = 64;
    private const int MAP_SIZE = 64;
    
    public TileMapManager(RenderWindow window)
    {
        _window = window;
        _textureManager = new TextureManager();
        _tileMaps = new List<Sprite[,]>
        {
            new Sprite[MAP_SIZE, MAP_SIZE]
        };
        CreateTileMap();
    }

    public void CreateTileMap()
    {
        Texture? grass = _textureManager.GetTexture("tile_0029_grass6.png");
        Texture? dirt = _textureManager.GetTexture("tile_0005_dirt6.png");
        for (int x = 0; x < _tileMaps[0].GetLength(0); x++)
        {
            for (int y = 0; y < _tileMaps[0].GetLength(1); y++)
            {
                Sprite tile = new Sprite(grass);
                if (y == 15)
                {
                    tile = new Sprite(dirt);
                }

                tile.Position = new Vector2f(x * TILE_SIZE, y * TILE_SIZE);
                _tileMaps[0][x, y] = tile;
            }
        }
    }

    public void Draw()
    {
        foreach (var tileMap in _tileMaps)
        {
            for (int x = 0; x < tileMap.GetLength(0); x++)
            {
                for (int y = 0; y < tileMap.GetLength(1); y++)
                {
                    _window.Draw(tileMap[x, y]);
                }
            }
        }
    }
}