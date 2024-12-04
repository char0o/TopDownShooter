using SFML.Graphics;
using SFML.System;

namespace TopDownShooter.Components;

public class BoundingBox
{
    public FloatRect Bounds { get; set; }
    public RectangleShape Rectangle { get; set; }

    public BoundingBox()
    {
        Bounds = new FloatRect();
        Rectangle = new RectangleShape();
        Rectangle.FillColor = new Color(255, 0, 0, 125);
    }

}