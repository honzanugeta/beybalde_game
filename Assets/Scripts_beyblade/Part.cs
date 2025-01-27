using UnityEngine;

public abstract class Part {
    protected abstract string partName { get; }
    public abstract int rarita { get; }
    public abstract float passive_dmg { get; } //0 pokud neni disk
    public abstract Material skin
    {
        get;
        set;
    }
    public enum Part_type
    {
        disk,
        ratchet,
        bit
    }
    
    public abstract Ability ability { get; }
    public abstract int Hp { get; set; }
    public abstract float speed { get; set; }
    public abstract float rotation_time { get; set; }
    public abstract float knockback_force { get; set; }

}
