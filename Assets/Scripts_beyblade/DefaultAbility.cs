using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultAbility : Ability
{

    public override bool reusable => true;
    public int countdown = 5;
    public override int Countdown { get => countdown; set => countdown = value; }

    public override KeyCode key => KeyCode.F;

    public override string Name => "Default Ability";

    public override bool isPassive => false;

    public override void runAbility()
    {
        Debug.Log("pressed default ability");
    }
}
