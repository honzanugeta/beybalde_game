using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpBit : Part
{
    public override int rarita => throw new System.NotImplementedException();

    public override float passive_dmg => 0;

    public override Material Skin { get; set; }

    public override Ability ability => new SpeedUpAbility();

    public override int Hp { get; set; }
    public override float Speed { get; set; } = 20;
    public override float Rotation_time { get; set; }
    public override float Knockback_force { get; set; }
}
