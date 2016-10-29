using UnityEngine;
using System.Collections;
using System;

public class AlwaysActivateCondition : ModuleCondition
{
    public override bool isConditionFilled()
    {
        return true;
    }
}
