using UnityEngine;
using System.Collections;

public abstract class ModuleEffect : MonoBehaviour
{
    public GameObject effectTarget;
    public ModuleCondition effectCondition;

    void Update()
    {
        if (effectCondition.isConditionFilled())
        {
            activateEffect();
        }
    }

    abstract public void activateEffect();
}
