using SFML.System;

namespace TopDownShooter.Util;

public static class MathHelper
{
    public static Vector2f AngleToDirection(float degrees)
    {
        // Convert degrees to radians
        float radians = degrees * (MathF.PI / 180.0f);

        // Calculate direction vector
        float x = (MathF.Cos(radians));
        float y = MathF.Sin(radians);

        return new Vector2f(x, y);
    }   
}