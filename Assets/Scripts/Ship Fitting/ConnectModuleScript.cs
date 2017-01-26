using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ConnectModuleScript : MonoBehaviour
{

    private static bool userCanMouse = true;
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
    void Start()
    {
        isDragging = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            transform.position = mouseWorldPosition;
            if (currentHoveredSlot && !currentHoveredSlot.GetComponent<Renderer>().enabled)
            {
                currentHoveredSlot.GetComponent<Renderer>().enabled = true;
                currentHoveredSlot.GetComponent<Collider2D>().enabled = true;
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
                currentHoveredSlot.GetComponent<Renderer>().enabled = false;
                currentHoveredSlot.GetComponent<Collider2D>().enabled = false;
                transform.parent = currentHoveredSlot.transform;
                currentHoveredSlot.SendMessageUpwards("ModuleHasBeenAttached", transform.gameObject);
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
        Debug.Log("Mouse Over");
        bool mouseCheck = Input.GetMouseButton(0);
        if (mouseCheck && userCanMouse)
        {
            Debug.Log("is Drag is now true");
            isDragging = true;
            userCanMouse = false;
        }
    }

    void OnMouseUp()
    {
        Debug.Log("UP UP");
        userCanMouse = true;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");

        if (other.tag == "LatchSlot")
        {
            isOverSlot = true;
            currentHoveredSlot = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Leave");

        if (other.tag == "LatchSlot")
        {
            isOverSlot = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enter2D " + other.tag);

        if (other.tag == "LatchSlot")
        {
            Debug.Log("Is Over Slot");
            isOverSlot = true;
            currentHoveredSlot = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Leave2D " + other.tag);

        if (other.tag == "LatchSlot")
        {
            isOverSlot = false;
        }
    }
}
