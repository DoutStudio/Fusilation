using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEditor;

public class ShipPanelScript : MonoBehaviour
{
    // A list of all ship modules in this panel
    // public GameObject[] listItemModules;
    public string FolderName;
    public GameObject listItem;


    private GameObject statPanel;
    private const string rootFolderName = "Ship Modules\\";

	// Use this for initialization
	void Start () {
        //while (!AssetPreview.IsLoadingAssetPreviews())
        //{
            //StartCoroutine(WaitForResourceLoad(10));
            GameObject[] listItemModules = Resources.LoadAll<GameObject>(rootFolderName + FolderName);
            statPanel = GameObject.Find("ModuleStatsPanel");

            for (int i = 0; i < listItemModules.Length; ++i)
            {
                GameObject newItem = Instantiate(listItem);
                newItem.GetComponent<ModuleThumbnailScript>().shipModule = listItemModules[i];
                newItem.GetComponent<ModuleThumbnailScript>().shipStatPanel = statPanel;
                //newItem.GetComponent<ConnectModuleScript>().enabled = true;
                newItem.transform.SetParent(transform);
            }
    }
}
