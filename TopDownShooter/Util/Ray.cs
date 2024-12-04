using SFML.Graphics;
using SFML.System;

namespace TopDownShooter.Util;

public class Ray
{
    public Vector2f Origin { get; set; }
    public Vector2f Direction { get; set; }
    
    public float Length { get; set; }

    public Ray(Vector2f origin, Vector2f direction, float length)
    {
        Origin = origin;
        Direction = direction;
        Length = length;
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
        float tLength = Length / (float)Math.Sqrt(Direction.X * Direction.X + Direction.Y * Direction.Y);
        return tMax >= tMin && tMin <= tLength && tMax >= 0;
    }

    public void Draw(RenderWindow window)
    {
        VertexArray vertexArray = new VertexArray(PrimitiveType.LineStrip);
        
        vertexArray.Append(new Vertex(new Vector2f(Origin.X, Origin.Y), Color.Blue));
        vertexArray.Append(new Vertex(new Vector2f(Origin.X + Direction.X * Length, Origin.Y + Direction.Y * Length), Color.Blue));
        
        window.Draw(vertexArray);
    }
}