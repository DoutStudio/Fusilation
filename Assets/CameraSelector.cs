using UnityEngine;
using System.Collections;

public class CameraSelector : MonoBehaviour
{

    public Camera MainCamera;
    public Camera Player1;
    public Camera Player2;

    // Use this for initialization
    void Start()
    {
        MainCamera.enabled = true;
        Player1.enabled = false;
        Player2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            MainCamera.enabled = true;
            Player1.enabled = false;
            Player2.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            MainCamera.enabled = false;
            Player1.enabled = true;
            Player2.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MainCamera.enabled = false;
            Player1.enabled = false;
            Player2.enabled = true;
        }
    }
}
