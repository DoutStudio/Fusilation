using UnityEngine;
using System.Collections;
using System;

public class FlatHealthEffect : ModuleEffect
{
    public float healthIncrease;

    ShipProperties shipProperties;

    public override void activateEffect()
    {
        // do nothing
    }

    public override void initEffect()
    {
        effectTarget = UtilScripts.FindParentWithTag(this.gameObject, "Ship");
        //effectCondition = GetComponent<AlwaysActivateCondition>();

        shipProperties = effectTarget.GetComponent<ShipProperties>();
        shipProperties.attackSpeedMultiplier += healthIncrease;
    }

    public override void removeEffect()
    {
        shipProperties.attackSpeedMultiplier -= healthIncrease;
    }
}
