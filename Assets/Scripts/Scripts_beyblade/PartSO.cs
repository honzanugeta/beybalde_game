using UnityEngine;

[CreateAssetMenu(fileName = "Part", menuName = "Beyblade/Part")]
public class PartSO : ScriptableObject
{
    // Unique identifier for the part
    public string partName;

    // Cost of the part
    public int cost;

    // Rarity of the part
    public PartRarity rarity;

    public GameObject mesh;

    // Damage, 0 if not applicable
    public float damage;

    // Type of the part
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

    // Material or appearance of the part
    public Material skin;
}
