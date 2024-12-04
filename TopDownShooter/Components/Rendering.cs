using SFML.Graphics;
using SFML.System;

namespace TopDownShooter.Components;

public class Rendering
{
    public Sprite Sprite { get; set; }

    public Rendering(Sprite sprite)
    {
        this.Sprite = sprite;
    }
}