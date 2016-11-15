using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public abstract class ModuleEffect : MonoBehaviour
{
    public GameObject effectTarget;
    private ModuleCondition effectCondition;

    void Start()
    {
        // used as temporary condition

        effectCondition = GetComponent<ModuleCondition>();
        if (!effectCondition)
        {
            effectCondition = gameObject.AddComponent<NeverActivateCondition>();
        }
    }


    void Update()
    {
        if (effectCondition.isConditionFilled())
        {
            activateEffect();
        }
    }

    abstract public void initEffect();
    abstract public void removeEffect();
    abstract public void activateEffect();
}
