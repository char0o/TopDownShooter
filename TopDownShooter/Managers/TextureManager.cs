using SFML.Graphics;

namespace TopDownShooter.Managers;

public class TextureManager
{
    private readonly Dictionary<string, Texture> _textures = new();

    public TextureManager()
    {
        Initialize();
    }

    public void Initialize()
    {
        var textures = Directory.GetFiles(Directory.GetCurrentDirectory() + "/resources/", "*.png", SearchOption.AllDirectories);

        foreach (string textureRef in textures)
        {
            string[] textureData = textureRef.Split('/');
            Console.WriteLine($"Loaded {textureData[^1]}");
            _textures[textureData[^1]] = new(textureRef);
        }
    }

    public Texture? GetTexture(string textureRef)
    {
        return _textures.GetValueOrDefault(textureRef);
    }

    public void PrintTextures()
    {
        foreach (var texture in _textures.Values)
        {
            Console.WriteLine(texture);
        }
    }
}