using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEditor;

public class ShipPanelScript : MonoBehaviour
{
    // A list of all ship modules in this panel
    public GameObject[] listItemModules;

    private GameObject statPanel;

	// Use this for initialization
	void Start () {
        //listItemModules = Resources.LoadAll<GameObject>("Attack");
        statPanel = GameObject.Find("ShipStatsPanel");
        GameObject childItem = transform.GetChild(0).gameObject;

        for (int i = 0; i < listItemModules.Length; ++i)
        {
            childItem.GetComponent<ModuleThumbnailScript>().shipModule = listItemModules[i];
            childItem.GetComponent<ModuleThumbnailScript>().shipStatPanel = statPanel;
            GameObject newItem = Instantiate(childItem);
            newItem.transform.SetParent(transform);
        }

        Debug.Log(listItemModules.Length);
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
