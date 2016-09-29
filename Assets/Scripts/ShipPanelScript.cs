using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEditor;

public class ShipPanelScript : MonoBehaviour
{
    // A list of all ship modules in this panel
    public GameObject[] listItemModules;
    public GameObject listItem;


    private GameObject statPanel;

	// Use this for initialization
	void Start () {
        //listItemModules = Resources.LoadAll<GameObject>("Attack");
        statPanel = GameObject.Find("ShipStatsPanel");

        for (int i = 0; i < listItemModules.Length; ++i)
        {
            GameObject newItem = Instantiate(listItem);
            newItem.GetComponent<ModuleThumbnailScript>().shipModule = listItemModules[i];
            newItem.GetComponent<ModuleThumbnailScript>().shipStatPanel = statPanel;
            newItem.transform.SetParent(transform);
        }

        Debug.Log(listItemModules.Length);
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
