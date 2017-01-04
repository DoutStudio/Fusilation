using UnityEngine;
using System.Collections;
/// <summary>
/// Ryan Scopio
/// rotates an object at static rate
/// </summary>
public class Rotate : MonoBehaviour
{

    public float DegreesPerSecond;

    void Update()
    {
        transform.Rotate(Vector3.forward * DegreesPerSecond * Time.deltaTime);
    }
}
