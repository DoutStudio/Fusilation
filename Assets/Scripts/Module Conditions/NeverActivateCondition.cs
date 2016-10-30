using UnityEngine;
using System.Collections;
using System;

public class NeverActivateCondition : ModuleCondition
{
    public override void initCondition()
    {
        // do nothing
    }

    public override bool isConditionFilled()
    {
        return false;
    }
}
