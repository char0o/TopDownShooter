using SFML.System;

namespace TopDownShooter.Components;

public class Transform
{
    public Vector2f Position { get; set; }
    public float Rotation { get; set; }
    public Vector2f Scale { get; set; }

    public Transform(Vector2f position, float rotation, Vector2f scale)
    {
        Position = position;
        Rotation = rotation;
        Scale = scale;
    }
}