using UnityEngine;
using System.Collections;
using System;

public class AlwaysActivateCondition : ModuleCondition
{
    public override void initCondition()
    {
        // do nothing
    }

    public override bool isConditionFilled()
    {
        return true;
    }

    public override void removeCondition()
    {
        // do nothing
    }
}
