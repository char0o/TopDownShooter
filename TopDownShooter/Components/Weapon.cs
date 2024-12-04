namespace TopDownShooter.Components;

public class Weapon
{
    public bool IsFiring { get; set; } = false;
    public float DelayBetweenShots { get; set; }
    public float TimeAccumulated { get; set; }
    public int Damage { get; set; }
}