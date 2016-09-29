using UnityEngine;
using System.Collections;

/// <summary>
/// Holds the target of the game object
/// finds new target when current target is defeated
/// </summary>
public class TargetingComputer : MonoBehaviour
{

    public GameObject Target;
    public Rigidbody2D TargetBody;
    public bool SimplePointToTarget = false;
    public float TurnSpeed = 20;

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
            if (collision.gameObject.tag == "Ship")
            {
                GameObject[] cores = GameObject.FindGameObjectsWithTag("Core");
                //check which target the ship is set to, default now is hull so...
                Target = cores[Random.Range(0, cores.Length - 1)];
                TargetBody = collision.gameObject.GetComponent<Rigidbody2D>();
            }
        }
    }
}
