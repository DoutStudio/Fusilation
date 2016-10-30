using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public abstract class ModuleEffect : MonoBehaviour
{
    public GameObject effectTarget;
    public ModuleCondition effectCondition;

    void Start()
    {
        // used as temporary condition
        effectCondition = new NeverActivateCondition();
    }


    void Update()
    {
        if (effectCondition.isConditionFilled())
        {
            activateEffect();
        }
    }

    abstract public void initEffect();
    abstract public void activateEffect();
}
