using UnityEngine;
using System.Collections;
using System;

public class AccuracyPercentageEffect : ModuleEffect
{
    [Range(0, 1)]
    public float accuracyMultiplier = 0;

    private ShipProperties shipProperties;

    public override void activateEffect()
    {
       // do nothing
    }

    public override void initEffect()
    {
        effectTarget = UtilScripts.FindParentWithTag(this.gameObject, "Ship");
        //effectCondition = GetComponent<AlwaysActivateCondition>();

        shipProperties = effectTarget.GetComponent<ShipProperties>();
        shipProperties.accuracyMultiplier += accuracyMultiplier;

    }

    public override void removeEffect()
    {
        shipProperties.accuracyMultiplier -= accuracyMultiplier;
    }
}
