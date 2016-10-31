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

    private void ApplyModuleBuff(GameObject module, bool isDebuff = false)
    {
        //int factor = 1;
        //if (isDebuff)
        //{
        //    factor = -1;
        //}

        //DescriptionScript moduleDesc = module.GetComponent<DescriptionScript>();
        //switch (moduleDesc.type)
        //{
        //    case DescriptionScript.ModuleType.ATTACK:
        //        Debug.Log("TODO: Apply Ship Attack BUFFERINOS");
        //        break;
        //    case DescriptionScript.ModuleType.DEFENSE:
        //        Debug.Log("TODO: Apply Ship Attack BUFFERINOS");
        //        break;
        //    case DescriptionScript.ModuleType.SUPPORT:
        //        Debug.Log("TODO: Apply Ship Attack BUFFERINOS");
        //        break;
        //}

        // Called delayed start functions
        // NOTE: order of these functions matter
        if (!isDebuff)
        {
            module.GetComponent<ModuleCondition>().initCondition();
            module.GetComponent<ModuleEffect>().initEffect();
        }
        else
        {
            module.GetComponent<ModuleEffect>().removeEffect();
            module.GetComponent<ModuleCondition>().removeCondition();
        }
    }

    public void ModuleHasBeenAttached(GameObject module)
    {
        modules.Add(module);
        ApplyModuleBuff(module);
        //Debug.Log(modules.Count);
    }

    public void ModuleHasBeenRemoved(GameObject module)
    {
        modules.Remove(module);
        ApplyModuleBuff(module, true);
        //Debug.Log(modules.Count);
    }
}
