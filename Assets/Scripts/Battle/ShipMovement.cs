using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Ryan Scopio
/// Uses the physics body of an object to move to a set of points
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class ShipMovement : MonoBehaviour
{
    public float FloatSpeed = 2f;
    public float WarpSpeed = 200f;
    private float speed;
    public GameObject[] MovePoints;
    public List<GameObject> WarpPoints;
    public List<GameObject> StopPoints;
    public float TurnSpeed = 5;

    Rigidbody2D body;
    private Vector3 desiredVelocity;
    private float lastSqrMag;
    private int curP = 0;


    void Start()
    {
        speed = FloatSpeed;
        body = GetComponent<Rigidbody2D>();
        Vector3 directionalVector = (MovePoints[curP].transform.position - transform.position).normalized * speed;
        lastSqrMag = Mathf.Infinity;
        desiredVelocity = directionalVector;

        //WarpPoints = new List<GameObject>();
        //StopPoints = new List<GameObject>();

    }

    void Update()
    {
        //point to move point
        Vector3 diff = MovePoints[curP].transform.position - transform.position;
        diff.Normalize();
        float rot = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, rot - 90), TurnSpeed * Time.deltaTime);

        float sqrMag = (MovePoints[curP].transform.position - transform.position).sqrMagnitude;
        if (sqrMag > lastSqrMag)
        {
            desiredVelocity = Vector3.zero;
        }
        lastSqrMag = sqrMag;
    }

    void FixedUpdate()
    {
        body.velocity = desiredVelocity;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == MovePoints[curP])
        {
            if (WarpPoints.Contains(collision.gameObject))
            {
                speed = WarpSpeed;
            }
            if (StopPoints.Contains(collision.gameObject))
            {
                speed = FloatSpeed;
            }

            curP++;
            if (curP >= MovePoints.Length)
            {
                curP = 0;
            }
            Vector3 directionalVector = (MovePoints[curP].transform.position - transform.position).normalized * speed;
            lastSqrMag = Mathf.Infinity;
            desiredVelocity = directionalVector;
        }
    }
}
