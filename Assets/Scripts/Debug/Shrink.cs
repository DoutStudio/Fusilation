using UnityEngine;
using System.Collections;

/// <summary>
/// Ryan Scopio
/// [Not in use]
/// Shrinks object over time
/// Deletes item when too small
/// </summary>
public class Shrink : MonoBehaviour
{

    public float ShrinkRate = 1;

    void Start()
    {
        StartCoroutine(ShrinkRoutine());
    }

    IEnumerator ShrinkRoutine()
    {
        while (true)
        {
            transform.localScale *= ShrinkRate;
            yield return new WaitForSeconds(0.01f);
            if (transform.localScale.magnitude < 0.01f)
            {
                Destroy(transform.gameObject);
            }
        }
    }
}
