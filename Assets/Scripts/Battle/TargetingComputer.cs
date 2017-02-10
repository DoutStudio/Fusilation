using UnityEngine;
using System.Linq;
using System.Collections;

/// <summary>
/// Holds the target of the game object
/// finds new target when current target is defeated
/// </summary>
public class TargetingComputer : MonoBehaviour
{
    public enum TargetMode
    {
        Hull,
        Attack,
        Defense,
        Support
    }



    public GameObject Target;
    public Rigidbody2D TargetBody;
    public bool SimplePointToTarget = false;
    public float TurnSpeed = 20;

    [HideInInspector]
    public Vector3 defaultRotation;

    TargetMode targetMode = TargetMode.Hull;

    void Update()
    {
        //PointToTarget
        if (SimplePointToTarget && Target)
        {
            Vector3 diff = Target.transform.position - transform.position;
            diff.Normalize();
            float rot = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, rot - 90), TurnSpeed * Time.deltaTime);
        }

        //rotate to default
        if (!Target)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(defaultRotation), TurnSpeed * Time.deltaTime);
        }


        //CHECK IF ENEMY SHIP EXISTS
        if (Target && !Target.transform.root.gameObject.activeSelf)
        {
            Target = null;
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ship")
        {
            Target = null;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Target)
        {
            if (collision.tag == "Ship" && collision.gameObject != transform.root.gameObject)
            {
                //check which target the ship is set to, default now is hull so...
                if (targetMode == TargetMode.Hull)
                {
                    Transform[] cores = collision.GetComponentsInChildren<Transform>().Where(x => x.tag == "Core").ToArray();
                    Target = cores[Random.Range(0, cores.Length)].gameObject;
                    TargetBody = collision.gameObject.GetComponent<Rigidbody2D>();
                }
                if (targetMode == TargetMode.Attack)
                {

                }
                if (targetMode == TargetMode.Defense)
                {

                }
                if (targetMode == TargetMode.Support)
                {

                }

            }
        }
    }
}
