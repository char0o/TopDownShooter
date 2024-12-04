using SFML.Graphics;

namespace TopDownShooter.Components;

public class Camera
{
    public View View { get; set; }

    public Camera ()
    {
        View = new View(new FloatRect(0f, 0f, Game.ScreenSize.X, Game.ScreenSize.Y));
        View.Zoom(1.0f);
    }
}