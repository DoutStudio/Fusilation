using UnityEngine;
using System.Collections;

public class DescriptionScript : MonoBehaviour {

    public enum ModuleType
    {
        ATTACK,
        DEFENSE,
        SUPPORT,
        CAPTAIN
    }

    public string title;

    public string description;

    public ModuleType type;

    // Module Attributes
    public float firerate;
    public float delay;
    public float power;
}
