using UnityEngine;
using System.Collections;
using System;

public class AttackSpeedEffect : ModuleEffect
{
    [Range(0, 1)]
    public float attackSpeedMultiplier = 0;

    ShipProperties shipProperties;


    public override void initEffect()
    {
        effectTarget = UtilScripts.FindParentWithTag(this.gameObject, "Ship");
        //effectCondition = GetComponent<AlwaysActivateCondition>();

        shipProperties = effectTarget.GetComponent<ShipProperties>();
        shipProperties.attackSpeedMultiplier += attackSpeedMultiplier;
    }

    public override void activateEffect()
    {
        // the module only has a passive effect
    }

    public override void removeEffect()
    {
        shipProperties.attackSpeedMultiplier -= attackSpeedMultiplier;
    }
}
