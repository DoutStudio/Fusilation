using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ShipPanelScript : MonoBehaviour ,
    IPointerExitHandler
{
    GameObject[] listItemModules;

	// Use this for initialization
	void Start () {
        listItemModules = GameObject.FindGameObjectsWithTag("AttackModuleListItem");	
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        foreach (GameObject item in listItemModules)
        {
            ModuleThumbnailScript script = item.GetComponent<ModuleThumbnailScript>();
            if (script.isHeld)
            {
                script.SpawnModuleAtMousePosition();
            }
        }
    }
}
