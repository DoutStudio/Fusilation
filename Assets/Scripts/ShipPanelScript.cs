using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEditor;

public class ShipPanelScript : MonoBehaviour
{
    // A list of all ship modules in this panel
    public string folderPath;
    public GameObject listItem;

    private GameObject statPanel;

	// Use this for initialization
	void Start () {
        GameObject[] listItemModules = Resources.LoadAll<GameObject>(folderPath);

        statPanel = GameObject.Find("ModuleStatsPanel");

        for (int i = 0; i < listItemModules.Length; ++i)
        {
            GameObject newItem = Instantiate(listItem);
            newItem.GetComponent<ModuleThumbnailScript>().shipModule = listItemModules[i];
            newItem.GetComponent<ModuleThumbnailScript>().shipStatPanel = statPanel;
            newItem.transform.SetParent(transform);
        }
    }
}
