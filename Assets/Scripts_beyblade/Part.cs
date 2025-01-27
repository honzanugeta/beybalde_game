using UnityEngine;

public abstract class Part
{
    // Unique identifier for the part
    public abstract string PartName { get; }

    // Rarity of the part
    public abstract PartRarity Rarity { get; }

    // Passive damage, 0 if not applicable
    public abstract float PassiveDamage { get; }

    // Material or appearance of the part
    public abstract Material Skin { get; set; }

    // Enum for the type of part
    public enum PartType
    {
        Disk,
        Ratchet,
        Bit
    }

    // Enum for rarity of the part
    public enum PartRarity
    {
        Common,
        Rare,
        Epic,
        Legendary
    }

    // Ability associated with the part
    public abstract Ability Ability { get; }

    // Attributes of the part
    public abstract int Hp { get; set; }
    public abstract float Speed { get; set; }
    public abstract float RotationTime { get; set; }
    public abstract float KnockbackForce { get; set; }

    // Optional: Define common logic for parts if applicable
}
