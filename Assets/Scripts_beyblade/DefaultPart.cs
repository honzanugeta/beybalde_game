using UnityEngine;

public class DefaultPart : Part
{
    // Fields for private storage
    private int hp = 20;
    private float speed = 2;
    private float rotationTime = 10;
    private float knockbackForce = 10;
    private Material skin;

    // Override part attributes
    public override string PartName => "Default Part";
    public override PartRarity Rarity => PartRarity.Common;
    public override float PassiveDamage => 0;
    public override Material Skin
    {
        get => skin;
        set => skin = value;
    }

    public override Ability Ability => new DefaultAbility();

    public override int Hp
    {
        get => hp;
        set => hp = Mathf.Max(0, value); // Ensure HP is non-negative
    }

    public override float Speed
    {
        get => speed;
        set => speed = Mathf.Max(0, value); // Ensure speed is non-negative
    }

    public override float RotationTime
    {
        get => rotationTime;
        set => rotationTime = Mathf.Max(0, value); // Ensure rotation time is non-negative
    }

    public override float KnockbackForce
    {
        get => knockbackForce;
        set => knockbackForce = Mathf.Max(0, value); // Ensure knockback force is non-negative
    }

    // Define the type of part explicitly
    public PartType Type => PartType.Disk;
}
