using UnityEngine;
using System.Collections;

/// <summary>
/// Ryan Scopio
/// Object POINTS to a target
/// intitial impulse force should carry it to target
/// maybe later add actual movement torwards target
/// </summary>
[RequireComponent(typeof(Rigidbody2D), typeof(BulletController))]
public class Seek : MonoBehaviour
{
    public float TurnSpeed = 20;
    [HideInInspector]
    public float Power = 1;

    private GameObject target;
    private BulletController bulletController;

    void Start()
    {
        bulletController = GetComponent<BulletController>();
        target = bulletController.Target;
    }


    void Update()
    {
        target = bulletController.Target;

        //Pointing To the Object
        if (target)
        {
            Vector3 diff = target.transform.position - transform.position;
            diff.Normalize();
            float rot = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, rot - 90), TurnSpeed * Time.deltaTime);
        }
        //Translating To the Object
        transform.position += transform.up * Time.deltaTime * Power;

    }
}
