using SFML.System;

namespace TopDownShooter.Components;

public class Velocity
{
    public Vector2f Value { get; set; }

    public Velocity(Vector2f velocity)
    {
        Value = velocity;
    }
}