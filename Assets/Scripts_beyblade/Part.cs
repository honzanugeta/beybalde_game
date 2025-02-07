using UnityEngine;

public abstract class Part
{

    public Part(PartSO p)
    {
        this.partSO = p;
    }
    // Reference to the PartSO
    private PartSO partSO;

    // Override part attributes from PartSO
    public virtual string PartName => partSO.partName;
    public virtual PartSO.PartRarity Rarity => partSO.rarity;
    public virtual float PassiveDamage => partSO.passiveDamage;

    public virtual Material Skin
    {
        get => partSO.skin;
        set => partSO.skin = value; // This might modify the PartSO asset
    }

    public virtual Ability Ability => new DefaultAbility();

    public virtual int Hp
    {
        get => partSO.hp;
        set => partSO.hp = Mathf.Max(0, value); // Ensure HP is non-negative
    }

    public virtual float Speed
    {
        get => partSO.speed;
        set => partSO.speed = Mathf.Max(0, value); // Ensure speed is non-negative
    }

    public virtual float RotationTime
    {
        get => partSO.rotationTime;
        set => partSO.rotationTime = Mathf.Max(0, value); // Ensure rotation time is non-negative
    }

    public virtual float KnockbackForce
    {
        get => partSO.knockbackForce;
        set => partSO.knockbackForce = Mathf.Max(0, value); // Ensure knockback force is non-negative
    }

    // Define the type of part explicitly from PartSO
    public virtual PartSO.PartType Type => partSO.type;

    public virtual Sprite Icon
    {
        get => partSO.icon;
        // set => partSO.icon = value; // If you want to modify icon in runtime
    }
}
