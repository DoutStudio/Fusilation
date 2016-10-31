using UnityEngine;
using System.Collections.Generic;


public class ShipProperties : MonoBehaviour {

    public float damageBuffMultiplier = 0;
    public float flatDamageBuff = 0;
    public float attackSpeedMultiplier = 0;
    public float flatAttackSpeedBuff = 0;
    public float healthBuffMultiplier = 0;
    public float flatHealthBuff = 0;
    public float damageReductionPercentage = 0;
    public float accuracyMultiplier = 0;
    public List<GameObject> modules;
    public GameObject captain;
    // TODO: active abilities

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void ModuleHasBeenAttached(GameObject module)
    {
        modules.Add(module);
        module.GetComponent<ModuleCondition>().initCondition();
        module.GetComponent<ModuleEffect>().initEffect();
        //Debug.Log(modules.Count);
    }

    public void ModuleHasBeenRemoved(GameObject module)
    {
        modules.Remove(module);
        module.GetComponent<ModuleCondition>().removeCondition();
        module.GetComponent<ModuleEffect>().removeEffect();
        //Debug.Log(modules.Count);
    }
}
