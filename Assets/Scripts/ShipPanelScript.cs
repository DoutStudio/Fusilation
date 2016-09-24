using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ShipPanelScript : MonoBehaviour
{
    // A list of all ship modules in this panel
    GameObject[] listItemModules;

	// Use this for initialization
	void Start () {
        //listItemModules = Resources.LoadAll<GameObject>("Assets/Prefabs/Ship Modules/Attack");
        Debug.Log(listItemModules.Length);
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
