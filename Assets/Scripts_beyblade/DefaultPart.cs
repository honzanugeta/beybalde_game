using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultPart : Part
{
    public override int rarita => 1;

    public override Material Skin { get => skin; set => skin = value; }

    public Material skin;

    public override float passive_dmg => 0;

    public override Ability ability => new DefaultAbility();

    public int hp = 20;
    public override int Hp
    {
        get => hp;
        set => hp = value;
    }

    private float speed = 2;
    public override float Speed
    {
        get => speed;
        set => speed = value;
    }

    public float rotationTime = 10;
    public override float Rotation_time
    {
        get => rotationTime;
        set => rotationTime = value;
    }

    public float knockbackForce = 10;
    public override float Knockback_force
    {
        get => knockbackForce;
        set => knockbackForce = value;
    }

    public override string Name => "Default Part";

    public Part.Part_type type = Part.Part_type.disk;

}
