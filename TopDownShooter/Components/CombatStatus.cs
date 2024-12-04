namespace TopDownShooter.Components;

public class CombatStatus
{
    public int MaxHealth { get; set; } = 100;
    public int Health { get; set; }
    public bool IsAlive => Health > 0;
}