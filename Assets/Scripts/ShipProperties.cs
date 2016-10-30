using UnityEngine;
using System.Collections.Generic;


public class ShipProperties : MonoBehaviour {

    public float damageBuffMultiplier = 1;
    public float attackSpeedMultiplier = 1;
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
        module.GetComponent<ModuleCondition>().initCondition();
        module.GetComponent<ModuleEffect>().initEffect();
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
