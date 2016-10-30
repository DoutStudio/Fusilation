using UnityEngine;
using System.Collections;
using System;

[DisallowMultipleComponent]
public abstract class ModuleCondition : MonoBehaviour
{
    public abstract void initCondition();
    public abstract bool isConditionFilled();
}
