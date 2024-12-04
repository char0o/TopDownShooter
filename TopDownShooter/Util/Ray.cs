using SFML.Graphics;
using SFML.System;

namespace TopDownShooter.Util;

public class Ray
{
    public Vector2f Origin { get; set; }
    public Vector2f Direction { get; set; }

    public Ray(Vector2f origin, Vector2f direction)
    {
        Origin = origin;
        Direction = direction;
    }

    public bool IntersectsBox(FloatRect rect)
    {
        float tMin = (rect.Left - Origin.X) / Direction.X;
        float tMax = ((rect.Left + rect.Width) - Origin.X) / Direction.X;

        if (tMin > tMax)
            (tMin, tMax) = (tMax, tMin);

        float tMinY = (rect.Top - Origin.Y) / Direction.Y;
        float tMaxY = ((rect.Top + rect.Height) - Origin.Y) / Direction.Y;

        if (tMinY > tMaxY)
            (tMinY, tMaxY) = (tMaxY, tMinY);
        
        tMin = Math.Max(tMin, tMinY);
        tMax = Math.Min(tMax, tMaxY);
        
        return tMax >= tMin && tMax >= 0;
    }
}