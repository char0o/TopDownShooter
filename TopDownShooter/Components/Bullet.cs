using SFML.Graphics;
using SFML.System;

namespace TopDownShooter.Components;

public class Bullet
{
    public Vector2f Origin { get; set; }
    public Vector2f Direction { get; set; }
    public float Speed { get; set; }
    public float Duration { get; set; }
    public float TimeAccumulator { get; set; }
    public int Owner { get; set; }
    public int Damage { get; set; }

    public Bullet(Vector2f origin, Vector2f direction, float speed, float duration, int owner, int damage)
    {
        Origin = origin;
        Direction = direction;
        Speed = speed;
        Duration = duration;
        TimeAccumulator = 0;
        Owner = owner;
        Damage = damage;
    }
}