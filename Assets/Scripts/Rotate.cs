using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{

    public float DegreesPerSecond;

    void Update()
    {
        transform.Rotate(Vector3.forward * DegreesPerSecond * Time.deltaTime);
    }
}
