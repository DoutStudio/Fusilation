using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ConnectModuleScript : MonoBehaviour {

    //Transform moduleTransform;

    private static bool userCanMouse = false;
    bool isDragging;

    [HideInInspector]
    public bool isOverSlot = false;

    [HideInInspector]
    public GameObject currentHoveredSlot = null;

    Vector3 mouseWorldPosition
    {
        get
        {
            Vector3 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mPos.z = 0;
            return mPos;
        }
    }

	// Use this for initialization
	void Start () {
        //moduleTransform = GetComponent<Transform>(); // unneeded
        isDragging = true;
        //isOverSlot = false;
        //currentHoveredSlot = null;
	}
	
	// Update is called once per frame
	void Update () {
        if (isDragging)
        {
            transform.position = mouseWorldPosition;
            if (currentHoveredSlot && !currentHoveredSlot.GetComponent<Renderer>().enabled) 
            {
                //currentHoveredSlot.SetActive(true);
                currentHoveredSlot.GetComponent<Renderer>().enabled = true;
                currentHoveredSlot.GetComponent<BoxCollider>().enabled = true;
                transform.SendMessageUpwards("ModuleHasBeenRemoved", transform.gameObject);
            }
        }
        if (!Input.GetMouseButton(0) && isDragging)
        {
            isDragging = false;

            if (isOverSlot)
            {
                isOverSlot = false;
                transform.position = currentHoveredSlot.transform.position;
                //currentHoveredSlot.SetActive(false);
                currentHoveredSlot.GetComponent<Renderer>().enabled = false;
                currentHoveredSlot.GetComponent<BoxCollider>().enabled = false;
                transform.parent = currentHoveredSlot.transform;
                currentHoveredSlot.SendMessageUpwards("ModuleHasBeenAttached", transform.gameObject);
                //Debug.Log("set");
            }
            else
            {
                // if we are not over a slot then remove the module from existence
                Debug.Log("Module not attached -- Destroying Module");
                Destroy(transform.gameObject);
            }
        }
	}

    void OnMouseOver()
    {
        if (Input.GetMouseButton(0) && userCanMouse)
        {
            isDragging = true;
            userCanMouse = false;
        }
    }

    void OnMouseUp()
    {
        userCanMouse = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LatchSlot")
        {
            isOverSlot = true;
            currentHoveredSlot = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "LatchSlot")
        {
            isOverSlot = false;
        }
    }
}
