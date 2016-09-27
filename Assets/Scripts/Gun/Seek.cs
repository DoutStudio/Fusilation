using UnityEngine;
using System.Collections;

/// <summary>
/// Ryan Scopio
/// Object POINTS to a target
/// intitial impulse force should carry it to target
/// maybe later add actual movement torwards target
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class Seek : MonoBehaviour
{
    public float TurnSpeed = 20;
    [HideInInspector]
    public GameObject Target;
    [HideInInspector]
    public float Power = 1;

    void Start()
    {
    }


    void Update()
    {
        //Pointing To the Object
        Vector3 diff = Target.transform.position - transform.position;
        diff.Normalize();
        float rot = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, rot - 90), TurnSpeed * Time.deltaTime);

        //Translating To the Object
        transform.position += transform.up * Time.deltaTime * Power;

    }
}
