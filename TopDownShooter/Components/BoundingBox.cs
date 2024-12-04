using SFML.Graphics;
using SFML.System;

namespace TopDownShooter.Components;

public class BoundingBox
{
    public FloatRect Bounds { get; set; }
    public Color Color { get; set; }
    public BoundingBox()
    {
        Bounds = new FloatRect();
        Color = Color.White;
    }

}