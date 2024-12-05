using SFML.Graphics;

namespace TopDownShooter.Components;

public class SquareRendering
{
    public RectangleShape Shape { get; set; }

    public SquareRendering(RectangleShape shape)
    {
        Shape = shape;
    }
}