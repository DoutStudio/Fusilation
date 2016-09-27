using UnityEngine;
using System.Collections;

/// <summary>
/// Holds the target of the game object
/// finds new target when current target is defeated
/// </summary>
public class TargetingComputer : MonoBehaviour
{

    public GameObject Target;
    public bool SimplePointToTarget = false;
    public float TurnSpeed = 20;

    void Update()
    {
        //PointToTarget
        if (SimplePointToTarget)
        {
            Vector3 diff = Target.transform.position - transform.position;
            diff.Normalize();
            float rot = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, rot - 90), TurnSpeed * Time.deltaTime);
        }

        if (!Target)
        {
            //find target
        }
    }
}
