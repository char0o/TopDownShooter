using SFML.Graphics;
using SFML.System;

namespace TopDownShooter.Util;

public static class MathHelper
{
    public static Vector2f AngleToDirection(float degrees)
    {
        float radians = degrees * (MathF.PI / 180.0f);
        
        float x = MathF.Cos(radians);
        float y = MathF.Sin(radians);

        return new Vector2f(x, y);
    }

    public static Vector2f Normalize(Vector2f vector)
    {
        float length = MathF.Sqrt(vector.X * vector.X + vector.Y * vector.Y);

        if (length == 0)
            return new Vector2f();
        
        return new Vector2f(vector.X / length, vector.Y / length);
    }

    public static bool RectsIntersects(FloatRect rect1, FloatRect rect2)
    {
        return rect1.Intersects(rect2);
    }
}