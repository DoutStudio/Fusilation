using UnityEngine;
using System.Collections.Generic;


public class ShipProperties : MonoBehaviour {

    public float damageBuffMultiplier = 1;
    public float attackSpeedBuffMultiplier = 1;
    public List<GameObject> modules;
    // TODO: active abilities

	// Use this for initialization
	void Start () {
        
        
        
        //// Get all the modules on this fooken ship
        //Transform fitting = transform.FindChild("FittingSlots");
        //for (int i = 0; i < fitting.childCount; ++i)
        //{
        //    Transform child = fitting.GetChild(i);
        //    // if Latch slot is holding a valid module
        //    if (child.childCount > 0)
        //    {
        //        modules.Add(fitting.GetChild(0).gameObject);

        //        // apply any buffs or debuffs
        //        ApplyModuleBuff(fitting.GetChild(0).gameObject);
        //    }
        //}
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    private void ApplyModuleBuff(GameObject module, bool isDebuff = false)
    {
        int factor = 1;
        if (isDebuff)
        {
            factor = -1;
        }

        DescriptionScript moduleDesc = module.GetComponent<DescriptionScript>();
        switch (moduleDesc.type)
        {
            case DescriptionScript.ModuleType.ATTACK:
                Debug.Log("TODO: Apply Ship Attack BUFFERINOS");
                break;
            case DescriptionScript.ModuleType.DEFENSE:
                Debug.Log("TODO: Apply Ship Attack BUFFERINOS");
                break;
            case DescriptionScript.ModuleType.SUPPORT:
                Debug.Log("TODO: Apply Ship Attack BUFFERINOS");
                break;
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
