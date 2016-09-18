using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class ModuleThumbnailScript : MonoBehaviour ,
    IPointerExitHandler
{

    public GameObject shipModule;
    

	// Use this for initialization
	void Start () {
        // check to see if the slot connector module is installed
        if (shipModule.GetComponent<ConnectModuleScript>() == null)
        {
            shipModule.AddComponent<ConnectModuleScript>();
        }
        // check if the rigid body is added
        if (shipModule.GetComponent<Rigidbody>() == null)
        {
            shipModule.AddComponent<Rigidbody>();
            shipModule.GetComponent<Rigidbody>().useGravity = false;
        }
        // check if the module has a collider
        if (shipModule.GetComponent<Collider>() == null)
        {
            shipModule.AddComponent<SphereCollider>();
            shipModule.GetComponent<SphereCollider>().isTrigger = true;
        }

        // Set the name of the list item
        Transform childTransform = transform.FindChild("ItemNameText");
        childTransform.GetComponent<Text>().text = name;

    }
	
	// Update is called once per frame
	void Update () {

    }

    public void SpawnModuleAtMousePosition()
    {
        Vector3 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mPos.z = 0;
        GameObject module = (GameObject) Instantiate(shipModule, mPos, Quaternion.identity);
        module.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        Debug.Log("held is false");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0))
        {
            SpawnModuleAtMousePosition();
        }
    }
}
