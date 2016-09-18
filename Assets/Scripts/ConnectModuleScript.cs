using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ConnectModuleScript : MonoBehaviour {

    Transform moduleTransform;

    bool isDragging;
    bool isOverSlot;
    GameObject currentHoveredSlot;

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
        moduleTransform = GetComponent<Transform>(); // unneeded
        isDragging = true;
        isOverSlot = false;
        currentHoveredSlot = null;
	}
	
	// Update is called once per frame
	void Update () {
        if (isDragging)
        {
            moduleTransform.position = mouseWorldPosition;
            if (currentHoveredSlot && !currentHoveredSlot.active)
            {
                currentHoveredSlot.SetActive(true);
            }
        }
        if (!Input.GetMouseButton(0) && isDragging)
        {
            isDragging = false;

            if (isOverSlot)
            {
                isOverSlot = false;
                moduleTransform.position = currentHoveredSlot.transform.position;
                currentHoveredSlot.SetActive(false);
                //Debug.Log("set");
            }
            else
            {
                // if we are not over a slot then remove the module from existence
                Destroy(moduleTransform.gameObject);
            }
        }
	}

    void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            isDragging = true;
        }
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
