using UnityEngine;
using System.Collections;

public class DescriptionScript : MonoBehaviour {

    public enum ModuleType
    {
        ATTACK,
        DEFENSE,
        SUPPORT,
        CAPTAIN,
        SHIP
    }

    // Generic Properties
    public string title;
    public string description;
    public ModuleType type;

    // Attack Module Attributes
    //public float firerate;
    ////public float delay;
    //public float power;
    //public float attackSpeedBuff;

    // Defense Module Attributes

    // Support Module Attributes
}
