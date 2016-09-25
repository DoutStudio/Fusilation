using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;


public class SelectedItemScript : MonoBehaviour {

    Text titleTextScript;
    Text descTextScript;

	// Use this for initialization
	void Start () {
        titleTextScript = transform.FindChild("TitleText").GetComponent<Text>();
        descTextScript = transform.FindChild("DescriptionText").GetComponent<Text>();

        //titleTextScript.text = "";
        //descTextScript.text = "";
    }

    public void SelectedItemScript_itemSelected(object sender, EventArgs e)
    {
        Debug.Log("test");

        GameObject obj = ((ItemSelectedArgs)e).gameObject;

        titleTextScript.text = obj.GetComponent<DescriptionScript>().title;
        descTextScript.text = obj.GetComponent<DescriptionScript>().description;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
