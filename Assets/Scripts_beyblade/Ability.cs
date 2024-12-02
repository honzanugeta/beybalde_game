using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability {
    public abstract bool reusable { get; }
    public abstract int Countdown { get; set; } // -1 pokud neni reusable (nepouziva se)
    public abstract KeyCode key { get; }



    public abstract void runAbility();


}
