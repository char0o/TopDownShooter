namespace TopDownShooter.Components;

public class PlayerInput
{
    public bool MoveLeft { get; set; }
    public bool MoveRight { get; set; }
    public bool MoveUp { get; set; }
    public bool MoveDown { get; set; }
    public bool IsMoving => MoveLeft || MoveRight || MoveUp || MoveDown;
}