using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class TestMovement : MonoBehaviour
{
    public float Speed = 2f;
    public GameObject[] MovePoints;

    Rigidbody2D body;
    private Vector3 desiredVelocity;
    private float lastSqrMag;
    private int curP = 0;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        Vector3 directionalVector = (MovePoints[curP].transform.position - transform.position).normalized * Speed;
        lastSqrMag = Mathf.Infinity;
        desiredVelocity = directionalVector;
    }

    // Update is called once per frame
    void Update()
    {
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
            curP++;
            if (curP >= MovePoints.Length)
            {
                curP = 0;
            }
            Vector3 directionalVector = (MovePoints[curP].transform.position - transform.position).normalized * Speed;
            lastSqrMag = Mathf.Infinity;
            desiredVelocity = directionalVector;
        }
    }
}
