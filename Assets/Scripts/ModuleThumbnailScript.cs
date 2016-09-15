using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ModuleThumbnailScript : MonoBehaviour ,
    IDragHandler {

    public GameObject shipModule;

    public bool isHeld;



	// Use this for initialization
	void Start () {
        isHeld = false;
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void SpawnModuleAtMousePosition()
    {
        isHeld = false;
        Vector3 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mPos.z = 0;
        Instantiate(shipModule, mPos, Quaternion.identity);
        Debug.Log("held is false");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("draggin");
        isHeld = true;
    }
}
