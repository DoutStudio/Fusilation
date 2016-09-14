using UnityEngine;
using System.Collections;

public class TestMovement : MonoBehaviour
{

    public float speed = 0.05f;
    public float waitTime = 5;
    bool flip = true;
    float timer = 0f;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            timer = 0f;
            flip = !flip;
        }
        transform.position += transform.up * (flip ? speed : -speed);
    }
}
