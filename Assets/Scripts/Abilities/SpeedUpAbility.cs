using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpAbility : Ability
{
    public PlayerMovement playerMovement;
    public override bool reusable => true;

    public override int Countdown { get; set; }

    public override KeyCode key => KeyCode.W;


    public override void runAbility()
    {
        playerMovement.SpeedUp();
    }
}
