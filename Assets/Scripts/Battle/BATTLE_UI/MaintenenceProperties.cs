using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaintenenceProperties : MonoBehaviour {

    public Dropdown TargetDropDown;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int GetTargetDropDownValue()
    {
        return TargetDropDown.value;
    }
}
