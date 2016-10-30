using UnityEngine;
using System.Collections;
using System;

public class AttackSpeedEffect : ModuleEffect
{
    public float attackSpeedMultiplier = 0;

    ShipProperties shipProperties;


    public override void initEffect()
    {
        effectTarget = UtilScripts.FindParentWithTag(this.gameObject, "Ship");
        //effectCondition = GetComponent<AlwaysActivateCondition>();

        shipProperties = effectTarget.GetComponent<ShipProperties>();
        shipProperties.attackSpeedMultiplier *= (1 + attackSpeedMultiplier);
    }

    public override void activateEffect()
    {
        // the module only has a passive effect
    }
}
