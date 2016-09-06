using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Turnt : MonoBehaviour
{

    public float torque = 50f;

    private Vector3 defPos;
    private Quaternion defRot;
    private Vector3 defScale;
    private Rigidbody2D body;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        defPos = transform.position;
        defRot = transform.localRotation;
        defScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            body.AddTorque(torque * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            body.AddTorque(-torque * Time.fixedDeltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Reset();
        }
    }

    void Reset()
    {
        transform.position = defPos;
        transform.localRotation = defRot;
        transform.localScale = defScale;
        body.velocity = Vector3.zero;
    }
}
