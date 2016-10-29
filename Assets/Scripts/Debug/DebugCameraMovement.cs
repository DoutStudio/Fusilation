using UnityEngine;
using System.Collections;

public class DebugCameraMovement : MonoBehaviour
{

    public float Speed = 1f;
    public bool Track = false;
    public Transform Target;
    public Vector3 Offset;
    //public Vector3 Rotation;

    /// <summary>
    /// Ryan Scopio
    /// Translate camera with arrow keys
    /// </summary>
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, Speed, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -Speed, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-Speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Speed, 0, 0);
        }

        if (Track)
        {
            transform.position = new Vector3(Target.position.x + Offset.x, Target.position.y + Offset.y, transform.position.z);
            //transform.rotation = Quaternion.Euler(Rotation);
        }

    }





}
