using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Part {
    public abstract int rarita { get; }
    public abstract float passive_dmg { get; } //0 pokud neni disk
    public abstract Material Skin
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
    public abstract float Speed { get; set; }
    public abstract float Rotation_time { get; set; }
    public abstract float Knockback_force { get; set; }

}
