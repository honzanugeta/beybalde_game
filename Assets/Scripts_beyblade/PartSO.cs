using UnityEngine;

[CreateAssetMenu(fileName = "Part", menuName = "Beyblade/Part")]
public class PartSO : ScriptableObject
{
    // Unique identifier for the part
    public string partName;

    // Rarity of the part
    public PartRarity rarity;

    // Passive damage, 0 if not applicable
    public float passiveDamage;

    // Material or appearance of the part
    public Material skin;

    public PartType type;

    // Attributes of the part
    public int hp;
    public float speed;
    public float rotationTime;
    public float knockbackForce;

    public Sprite icon;

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
}
